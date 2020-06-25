using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOfficeTramitesWin.wcfTramite;
using System.Linq;

namespace BackOfficeTramitesWin
{
    public partial class frmListadoSolicitudes : Form
    {
        ServiceClient wcf = new ServiceClient();
        Empleado empleadoLogueado = null;
        List<Solicitud> solicitudes = new List<Solicitud>();
        List<Tramite> tramites = new List<Tramite>();
        List<Documentacion> documentacion = new List<Documentacion>();
        public frmListadoSolicitudes(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;

            ListarSolicitudes(empleado);
        }

        private void ListarSolicitudes(Empleado empleado)
        {
            try
            {
                empleadoLogueado = empleado;
                //documentacion = FabricaLogica.GetLogicaDocumentacion().listadoDocumentacion(empleado);
                //tramites = FabricaLogica.GetLogicaTramite().ListarTramites();
                //solicitudes = FabricaLogica.GetLogicaSolicitud().listadoSolicitud(empleado);
                documentacion = wcf.listadoDocumentacion(empleado).ToList<Documentacion>();
                tramites = wcf.ListarTramites().ToList<Tramite>();
                solicitudes = wcf.listadoSolicitud(empleado).ToList<Solicitud>();
                var res = (from sol in solicitudes
                           select new
                           {
                               Numero = sol.Numero.ToString(),
                               Estado = sol.Estado,
                               Fecha = sol.FechaHora.ToShortDateString(),
                               Solicitante = sol.Solicitante.NombreCompleto,
                               Tramite = sol.Tramite.NombreTramite
                           }).ToList();

                dgvSolicitudes.AutoGenerateColumns = true;
                dgvSolicitudes.DataSource = res;

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void btnXTramite_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = (from sol in solicitudes
                                 orderby sol.Tramite.NombreTramite
                                 group sol by sol.Tramite.NombreTramite into grupo
                                 select new
                                 {
                                     Nombre = grupo.Key.ToString(),
                                     Cantidad = grupo.Count()

                                 }).ToList();
                dgvSolicitudes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void btnXMes_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = (from sol in solicitudes
                                 orderby sol.FechaHora.Date
                                 group sol by sol.FechaHora.Date into grupo
                                 select new
                                 {
                                     Mes = grupo.Key.Month,
                                     Cantidad = grupo.Count()

                                 }).ToList();
                dgvSolicitudes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void btnXDocumentacion_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = (from sol in solicitudes
                                 join tr in tramites on sol.Tramite.CodigoTramite equals tr.CodigoTramite
                                 from doc in tr.DocumentacionExigida
                                 group doc by doc.CodigoInterno into doc
                                 join d in documentacion on doc.Key equals d.CodigoInterno
                                 select new
                                 {
                                     Documento = d.NomDocumentacion,
                                     Cantidad = doc.Count()
                                 }
                                    ).ToList();
                dgvSolicitudes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void btnXFecha_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = new DateTime();
            try
            {
                fechaSeleccionada = new DateTime(DateTime.Today.Year, Convert.ToInt32(dtpFecha.Value.Month), Convert.ToInt32(dtpFecha.Value.Day));
            }
            catch (Exception)
            {
                lblMensaje.Text = "Seleccione una fecha válida";
            }

            try
            {
                var resultado = (from sol in solicitudes
                                 orderby sol.FechaHora.Hour
                                 where sol.FechaHora.Date == (fechaSeleccionada.Date)
                                 select new
                                 {
                                     Numero = sol.Numero.ToString(),
                                     Estado = sol.Estado,
                                     Fecha = sol.FechaHora.ToShortDateString(),
                                     Solicitante = sol.Solicitante.NombreCompleto,
                                     Tramite = sol.Tramite.NombreTramite
                                 }
                                ).ToList();
                dgvSolicitudes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ListarSolicitudes(empleadoLogueado);
        }
    }
}
