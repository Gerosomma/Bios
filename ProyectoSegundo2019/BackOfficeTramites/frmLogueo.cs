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
using System.Xml;
using System.IO;

namespace BackOfficeTramites
{
    public partial class frmLogueo : Form
    {
        ServiceClient wcf = new ServiceClient();
        public frmLogueo()
        {
            InitializeComponent();
            //creo el controlador del evento de logueo del ControlLogueo
            controlLogueo1.AutenticarUsuario += new EventHandler(VerificoIngreso);
        }

        public void VerificoIngreso(object sender, EventArgs e)
        {
            try
            {
                //Empleado _unEmpleado = (Empleado)FabricaLogica.GetLogicaUsuario().LogueoUsuario(controlLogueo1.Usuario, controlLogueo1.Contrasena);
                Empleado _unEmpleado = (Empleado)wcf.LogueoUsuario(controlLogueo1.Usuario, controlLogueo1.Contrasena);

                if (_unEmpleado == null)
                    lblError.Text = "CI o Pass Invalidos";
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement raiz = doc.CreateElement("EmpleadoLogueado");

                    doc.AppendChild(raiz);

                    XmlElement documento = doc.CreateElement("Documento");
                    XmlText textoDocumento = doc.CreateTextNode(_unEmpleado.Documento.ToString());
                    documento.AppendChild(textoDocumento);
                    raiz.AppendChild(documento);

                    XmlElement pw = doc.CreateElement("Contrasenia");
                    XmlText textoPw = doc.CreateTextNode(_unEmpleado.Contrasenia);
                    pw.AppendChild(textoPw);
                    raiz.AppendChild(pw);

                    XmlElement nombre = doc.CreateElement("Nombre");
                    XmlText textoNombre = doc.CreateTextNode(_unEmpleado.NombreCompleto);
                    nombre.AppendChild(textoNombre);
                    raiz.AppendChild(nombre);

                    XmlElement inicio = doc.CreateElement("Inicio");
                    XmlText textoInicio = doc.CreateTextNode(_unEmpleado.HoraInicio);
                    inicio.AppendChild(textoInicio);
                    raiz.AppendChild(inicio);

                    XmlElement fin = doc.CreateElement("Fin");
                    XmlText textoFin = doc.CreateTextNode(_unEmpleado.HoraFin);
                    fin.AppendChild(textoFin);
                    raiz.AppendChild(fin);
                    string ruta = Path.Combine(@"XML\empleadoLogueado.xml");
                    doc.Save(ruta);

                    this.Hide();
                    Form _unForm = new frmPrincipal(_unEmpleado);
                    _unForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
