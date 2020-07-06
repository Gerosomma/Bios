using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOfficeTramites.wcfTramite;
using System.Linq;

namespace BackOfficeTramites
{
    public partial class frmListadoSolicitudes : Form
    {
        Empleado empleadoLogueado = null;
        List<Solicitud> solicitudes = new List<Solicitud>();
        List<Tramite> tramites = new List<Tramite>();
        List<Documentacion> documentacion = new List<Documentacion>();
        String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public frmListadoSolicitudes(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;
            ListarSolicitudes(empleado);
            dtpFecha.MinDate = new DateTime(DateTime.Today.Year, 1, 1);
            dtpFecha.MaxDate = new DateTime(DateTime.Today.Year, 12, 31);
            lblTitulo.Text += DateTime.Today.Year.ToString();
        }

        private void ListarSolicitudes(Empleado empleado)
        {
            try
            {
                empleadoLogueado = empleado;
                ServiceClient wcf = new ServiceClient();
                documentacion = wcf.listadoDocumentacion(empleado).ToList<Documentacion>();
                tramites = wcf.ListarTramites().ToList<Tramite>();
                solicitudes = wcf.listadoSolicitudXanio(empleado).ToList<Solicitud>();
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
                lblMensaje.Text = "";
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
                lblMensaje.Text = "Solicitudes filtradas por tramite.";
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
                                     Mes = meses[grupo.Key.Month -1],
                                     Cantidad = grupo.Count()

                                 }).ToList();
                dgvSolicitudes.DataSource = resultado;
                lblMensaje.Text = "Solicitudes filtradas por mes.";
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
                lblMensaje.Text = "Solicitudes filtradas por documentacion.";
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
                lblMensaje.Text = "Solicitudes filtradas por fecha " + fechaSeleccionada.ToShortDateString() + ".";
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
