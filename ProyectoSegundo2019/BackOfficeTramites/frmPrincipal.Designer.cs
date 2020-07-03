namespace BackOfficeTramites
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTramite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeSolicitudesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEmpleado,
            this.tsmDocumentos,
            this.tsmTramite,
            this.tsmSolicitudes,
            this.tsmSalir,
            this.listadoDeSolicitudesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmEmpleado
            // 
            this.tsmEmpleado.Name = "tsmEmpleado";
            this.tsmEmpleado.Size = new System.Drawing.Size(72, 20);
            this.tsmEmpleado.Text = "Empleado";
            this.tsmEmpleado.Click += new System.EventHandler(this.tsmEmpleado_Click);
            // 
            // tsmDocumentos
            // 
            this.tsmDocumentos.Name = "tsmDocumentos";
            this.tsmDocumentos.Size = new System.Drawing.Size(82, 20);
            this.tsmDocumentos.Text = "Documento";
            this.tsmDocumentos.Click += new System.EventHandler(this.tsmDocumentos_Click);
            // 
            // tsmTramite
            // 
            this.tsmTramite.Name = "tsmTramite";
            this.tsmTramite.Size = new System.Drawing.Size(58, 20);
            this.tsmTramite.Text = "Tramite";
            this.tsmTramite.Click += new System.EventHandler(this.tsmTramite_Click);
            // 
            // tsmSolicitudes
            // 
            this.tsmSolicitudes.Name = "tsmSolicitudes";
            this.tsmSolicitudes.Size = new System.Drawing.Size(65, 20);
            this.tsmSolicitudes.Text = "Solicitud";
            this.tsmSolicitudes.Click += new System.EventHandler(this.tsmSolicitudes_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmSalir.Size = new System.Drawing.Size(41, 20);
            this.tsmSalir.Text = "Salir";
            this.tsmSalir.Click += new System.EventHandler(this.tsmSalir_Click);
            // 
            // listadoDeSolicitudesToolStripMenuItem
            // 
            this.listadoDeSolicitudesToolStripMenuItem.Name = "listadoDeSolicitudesToolStripMenuItem";
            this.listadoDeSolicitudesToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.listadoDeSolicitudesToolStripMenuItem.Text = "Listado de solicitudes";
            this.listadoDeSolicitudesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeSolicitudesToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 701);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "Formulario principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmEmpleado;
        private System.Windows.Forms.ToolStripMenuItem tsmDocumentos;
        private System.Windows.Forms.ToolStripMenuItem tsmTramite;
        private System.Windows.Forms.ToolStripMenuItem tsmSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem listadoDeSolicitudesToolStripMenuItem;
    }
}