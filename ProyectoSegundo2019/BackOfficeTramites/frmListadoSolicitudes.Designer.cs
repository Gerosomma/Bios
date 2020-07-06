namespace BackOfficeTramites
{
    partial class frmListadoSolicitudes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoSolicitudes));
            this.btnXFecha = new System.Windows.Forms.Button();
            this.btnXDocumentacion = new System.Windows.Forms.Button();
            this.btnXMes = new System.Windows.Forms.Button();
            this.btnXTramite = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXFecha
            // 
            this.btnXFecha.Location = new System.Drawing.Point(549, 43);
            this.btnXFecha.Name = "btnXFecha";
            this.btnXFecha.Size = new System.Drawing.Size(75, 40);
            this.btnXFecha.TabIndex = 16;
            this.btnXFecha.Text = "Filtrar x Fecha";
            this.btnXFecha.UseVisualStyleBackColor = true;
            this.btnXFecha.Click += new System.EventHandler(this.btnXFecha_Click);
            // 
            // btnXDocumentacion
            // 
            this.btnXDocumentacion.Location = new System.Drawing.Point(187, 43);
            this.btnXDocumentacion.Name = "btnXDocumentacion";
            this.btnXDocumentacion.Size = new System.Drawing.Size(91, 40);
            this.btnXDocumentacion.TabIndex = 15;
            this.btnXDocumentacion.Text = "Resumen x Documentacion";
            this.btnXDocumentacion.UseVisualStyleBackColor = true;
            this.btnXDocumentacion.Click += new System.EventHandler(this.btnXDocumentacion_Click);
            // 
            // btnXMes
            // 
            this.btnXMes.Location = new System.Drawing.Point(105, 43);
            this.btnXMes.Name = "btnXMes";
            this.btnXMes.Size = new System.Drawing.Size(75, 40);
            this.btnXMes.TabIndex = 14;
            this.btnXMes.Text = "Resumen Mensual";
            this.btnXMes.UseVisualStyleBackColor = true;
            this.btnXMes.Click += new System.EventHandler(this.btnXMes_Click);
            // 
            // btnXTramite
            // 
            this.btnXTramite.Location = new System.Drawing.Point(23, 43);
            this.btnXTramite.Name = "btnXTramite";
            this.btnXTramite.Size = new System.Drawing.Size(75, 40);
            this.btnXTramite.TabIndex = 13;
            this.btnXTramite.Text = "Resumen x Tramite";
            this.btnXTramite.UseVisualStyleBackColor = true;
            this.btnXTramite.Click += new System.EventHandler(this.btnXTramite_Click);
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 118);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.Size = new System.Drawing.Size(719, 391);
            this.dgvSolicitudes.TabIndex = 12;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(419, 63);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(111, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(652, 63);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(79, 34);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Seleccione una fecha:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(13, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 13);
            this.lblTitulo.TabIndex = 24;
            this.lblTitulo.Text = "Resumen de solicitudes para el año: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(412, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 64);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 64);
            this.panel2.TabIndex = 26;
            // 
            // frmListadoSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 550);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnXFecha);
            this.Controls.Add(this.btnXDocumentacion);
            this.Controls.Add(this.btnXMes);
            this.Controls.Add(this.btnXTramite);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListadoSolicitudes";
            this.Text = "Listados de Solicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXFecha;
        private System.Windows.Forms.Button btnXDocumentacion;
        private System.Windows.Forms.Button btnXMes;
        private System.Windows.Forms.Button btnXTramite;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}