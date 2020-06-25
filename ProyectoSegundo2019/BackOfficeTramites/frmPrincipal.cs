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
using System.IO;


namespace BackOfficeTramites
{
    public partial class frmPrincipal : Form
    {
        Empleado empleadoLogueado = null;
        public frmPrincipal(Empleado empleado)
        {
            InitializeComponent();
            empleadoLogueado = empleado;
        }

        private void tsmEmpleado_Click(object sender, EventArgs e)
        {
            Form frm = new frmABMEmpleado(empleadoLogueado);
            frm.Show();
        }

        private void tsmDocumentos_Click(object sender, EventArgs e)
        {
            Form frm = new frmABMDocumentacion(empleadoLogueado);
            frm.Show();
        }

        private void tsmTramite_Click(object sender, EventArgs e)
        {
            Form frm = new frmABMTramite(empleadoLogueado);
            frm.Show();
        }

        private void tsmSolicitudes_Click(object sender, EventArgs e)
        {
            Form frm = new frmSolicitud(empleadoLogueado);
            frm.Show();
        }

        private void listadoDeSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListadoSolicitudes(empleadoLogueado);
            frm.Show();
        }

        private void tsmSalir_Click(object sender, EventArgs e)
        {
            string ruta = Path.Combine(Application.StartupPath, @"XML\empleadoLogueado.xml");
            File.Delete(ruta);
            Application.Exit();
        }
    }
}
