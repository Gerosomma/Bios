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
    public partial class frmABMDocumentacion : Form
    {
        private Empleado empleadoLogueado = null;
        private Documentacion documentacion = null;
        ServiceClient wcf = new ServiceClient();

        public frmABMDocumentacion(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
            int numero = 0;
            try
            {
                numero = Convert.ToInt32(txtNumero.Text);
            }
            catch (FormatException ex)
            {
                LblError.Text = "Numero es invalido.";
            }

            try
            {
                //Documentacion unaDocumentacion = FabricaLogica.GetLogicaDocumentacion().BuscarDocumentacion(numero);
                Documentacion unaDocumentacion = wcf.BuscarDocumentacion(numero);
                
                if (unaDocumentacion == null)
                {
                    BtnAlta.Enabled = true;
                    txtNumero.Enabled = false;
                }
                else
                {
                    BtnModificar.Enabled = true;
                    BtnBaja.Enabled = true;
                    documentacion = unaDocumentacion;
                    txtNumero.Text = unaDocumentacion.CodigoInterno.ToString();
                    txtNombre.Text = unaDocumentacion.NomDocumentacion;
                    txtLugar.Text = unaDocumentacion.Lugar;
                    txtNumero.Enabled = false;
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

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Documentacion doc = new Documentacion();
                doc.CodigoInterno = Convert.ToInt32(txtNumero.Text);
                doc.NomDocumentacion = txtNombre.Text.Trim();
                doc.Lugar = txtLugar.Text;

                //FabricaLogica.GetLogicaDocumentacion().AltaDocumentacion(empleado, empleadoLogueado);
                wcf.AltaDocumentacion(doc, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();

                txtNumero.Enabled = true;
                txtNumero.ReadOnly = false;

                LblError.Text = "Alta con Exito";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                //FabricaLogica.GetLogicaDocumentacion().BajaDocumentacion(documentacion, empleadoLogueado);
                wcf.BajaDocumentacion(documentacion, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();
                txtNumero.Enabled = true;
                txtNumero.ReadOnly = false;

                LblError.Text = "Baja con Exito";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                documentacion.NomDocumentacion = txtNombre.Text.Trim();
                documentacion.CodigoInterno = Convert.ToInt32(txtNumero.Text.Trim());
                documentacion.Lugar = txtLugar.Text.Trim();

                //FabricaLogica.GetLogicaDocumentacion().ModificarDocumentacion(documentacion, empleadoLogueado);
                wcf.ModificarDocumentacion(documentacion, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();

                txtNumero.Enabled = true;
                txtNumero.ReadOnly = false;

                LblError.Text = "Modificacion con Exito";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    LblError.Text = ex.Message.Substring(0, 40);
                else
                    LblError.Text = ex.Message;
            }
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            DesActivoBotones();
            LimpioControles();
        }

        private void DesActivoBotones()
        {
            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void LimpioControles()
        {
            txtNumero.Text = "";
            txtNombre.Text = "";
            txtLugar.Text = "";
            LblError.Text = "";
            txtNumero.Enabled = true;
        }

    }
}
