using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisControles
{
    public partial class controlLogueo : UserControl
    {
        public controlLogueo()
        {
            InitializeComponent();
        }

        public int Usuario
        {
            get { return (Convert.ToInt32(txtUsuario.Text.Trim())); }
        }

        public string Contrasena
        {
            get { return (txtContrasena.Text.Trim()); }
        }


        //defino evento para logueo
        public event EventHandler AutenticarUsuario;

        //provoco el evento de logueo cuando se presiona el boton
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AutenticarUsuario(this, new EventArgs());
        }
    }
}
