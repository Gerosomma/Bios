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

            try
            {
                ServiceClient wcf = new ServiceClient();
                listaSolicitudes = wcf.listadoSolicitud(empleadoLogueado).ToList<Solicitud>();
                dgvSolicitudes.AutoGenerateColumns = true;
                dgvSolicitudes.DataSource = listaSolicitudes;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void RecargarLista()
        {
            try
            {
                ServiceClient wcf = new ServiceClient();
                listaSolicitudes = wcf.listadoSolicitud(empleadoLogueado).ToList<Solicitud>();
                dgvSolicitudes.DataSource = listaSolicitudes;
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

                LblError.Text = "Solicitudes modificadas con éxito";
                RecargarLista();
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

                LblError.Text = "Solicitudes modificadas con éxito";
                RecargarLista();

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
