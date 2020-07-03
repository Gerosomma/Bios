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

namespace BackOfficeTramites
{
    public partial class frmSolicitud : Form
    {
        Empleado empleadoLogueado = null;
        List<Solicitud> listaSolicitudes = new List<Solicitud>();
        public frmSolicitud(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;
            RecargarLista();
        }

        private void RecargarLista()
        {
            try
            {
                ServiceClient wcf = new ServiceClient();
                listaSolicitudes = wcf.listadoSolicitud(empleadoLogueado).ToList<Solicitud>();
                var res = (from sol in listaSolicitudes
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

                DataGridViewButtonColumn colEjecutar = new DataGridViewButtonColumn();
                colEjecutar.Name = "Ejecturar";
                colEjecutar.Text = "Ejecturar";
                colEjecutar.UseColumnTextForButtonValue = true;
                colEjecutar.HeaderText = "Ejecutar";

                DataGridViewButtonColumn colAnular = new DataGridViewButtonColumn();
                colAnular.Name = "Anular";
                colAnular.Text = "Anular";
                colAnular.UseColumnTextForButtonValue = true;
                colAnular.HeaderText = "Anular";

                dgvSolicitudes.Columns.Add(colEjecutar);
                dgvSolicitudes.Columns.Add(colAnular);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void btnEjecutar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Solicitud solicitud = null;
                int accion;
                if (dgvSolicitudes.SelectedRows.Count != 0)
                {
                    ServiceClient wcf = new ServiceClient();

                    foreach (DataGridViewRow fila in dgvSolicitudes.SelectedRows)
                    {
                        if (fila.Selected)
                        {
                            accion = 1;
                            solicitud = wcf.BuscarSolicitud(Convert.ToInt32(fila.Cells["Numero"].Value), empleadoLogueado);
                            wcf.CambiarEstadoSolicitud(solicitud.Numero, accion, empleadoLogueado);
                        }
                    }

                    LblError.Text = "Solicitudes ejecutadas con éxito";
                    RecargarLista();
                }
                else
                {
                    LblError.Text = "No selecciono Solicitud.";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void btnRechazada_Click_1(object sender, EventArgs e)
        {
            try
            {
                Solicitud solicitud = null;
                int accion;
                if (dgvSolicitudes.SelectedRows.Count != 0)
                {
                    ServiceClient wcf = new ServiceClient();
                    foreach (DataGridViewRow fila in dgvSolicitudes.SelectedRows)
                    {
                        if (fila.Selected)
                        {
                            accion = 2;
                            solicitud = wcf.BuscarSolicitud(Convert.ToInt32(fila.Cells["Numero"].Value), empleadoLogueado);
                            wcf.CambiarEstadoSolicitud(solicitud.Numero, accion, empleadoLogueado);
                        }
                    }

                    LblError.Text = "Solicitudes anuladas con éxito";
                    RecargarLista();
                }
                else
                {
                    LblError.Text = "No selecciono Solicitud.";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }
    }
}
