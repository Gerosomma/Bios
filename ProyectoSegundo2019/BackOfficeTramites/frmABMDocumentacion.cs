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
using MisControles;

namespace BackOfficeTramites
{
    public partial class frmABMDocumentacion : Form
    { 
        private Empleado empleadoLogueado = null;
        private Documentacion documentacion = null;

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
            
                ServiceClient wcf = new ServiceClient();
                Documentacion unaDocumentacion = wcf.BuscarDocumentacionAux(numero);
                
                if (unaDocumentacion == null)
                {
                    BtnAlta.Enabled = true;
                    txtNumero.Enabled = false;
                    LblError.Text = "No existe documento, agregelo.";
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
                    btnActivo.Text = "Activo";

                    if (!unaDocumentacion.Activo)
                    {
                        btnActivo.Enabled = true;
                        LblError.Text = "El documento esta inactivo.";
                        btnActivo.Image = BackOfficeTramites.Properties.Resources.inactivo;
                        btnActivo.Text = "Activar";
                    }
                }
            }
            catch (FormatException)
            {
                LblError.Text = "Numero es inválido.";
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

                ServiceClient wcf = new ServiceClient();
                wcf.AltaDocumentacion(doc, empleadoLogueado);
                this.DesActivoBotones();
                this.LimpioControles();

                txtNumero.Enabled = true;
                txtNumero.ReadOnly = false;
                LblError.Text = "Alta con Exito";

                if (!documentacion.Activo)
                {
                    LblError.Text = "Se activo la documentacion con Exito";
                }
            }
            catch (FormatException)
            {
                LblError.Text = "Numero es inválido.";
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
                ServiceClient wcf = new ServiceClient();
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

                ServiceClient wcf = new ServiceClient();
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
            btnActivo.Enabled = false;
        }

        private void LimpioControles()
        {
            txtNumero.Text = "";
            txtNombre.Text = "";
            txtLugar.Text = "";
            LblError.Text = "";
            btnActivo.Text = "Activo";
            txtNumero.Enabled = true;
            btnActivo.Image = BackOfficeTramites.Properties.Resources.activo;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            utiles.soloNumeros(e);
        }
    }
}
