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
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void dgvSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Solicitud solicitud = null;
            int accion, numero;
            switch (dgvSolicitudes.Columns[e.ColumnIndex].Name)
            {
                case "Ejecutar":
                    try
                    {
                        accion = 1;
                        numero = Convert.ToInt32(dgvSolicitudes.Rows[e.RowIndex].Cells["Numero"].Value);
                        ServiceClient wcf = new ServiceClient();
                        solicitud = wcf.BuscarSolicitud(numero, empleadoLogueado);
                        wcf.CambiarEstadoSolicitud(solicitud.Numero, accion, empleadoLogueado);
                        LblError.Text = "Solicitud ejecutada con éxito";
                        RecargarLista();
                    }
                    catch (Exception ex)
                    {
                        LblError.Text = ex.Message;
                    }
                    break;
                case "Anular":
                    try
                    {
                        accion = 2;
                        numero = Convert.ToInt32(dgvSolicitudes.Rows[e.RowIndex].Cells["Numero"].Value);
                        ServiceClient wcf2 = new ServiceClient();
                        solicitud = wcf2.BuscarSolicitud(numero, empleadoLogueado);
                        wcf2.CambiarEstadoSolicitud(solicitud.Numero, accion, empleadoLogueado);
                        LblError.Text = "Solicitud anulada con éxito";
                        RecargarLista();
                    }
                    catch (Exception ex)
                    {
                        LblError.Text = ex.Message;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
