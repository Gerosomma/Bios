namespace BackOfficeTramitesWin
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnXFecha = new System.Windows.Forms.Button();
            this.btnXDocumentacion = new System.Windows.Forms.Button();
            this.btnXMes = new System.Windows.Forms.Button();
            this.btnXTramite = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlMes = new System.Windows.Forms.ComboBox();
            this.ddlDia = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(652, 13);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(79, 40);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnXFecha
            // 
            this.btnXFecha.Location = new System.Drawing.Point(549, 13);
            this.btnXFecha.Name = "btnXFecha";
            this.btnXFecha.Size = new System.Drawing.Size(75, 40);
            this.btnXFecha.TabIndex = 16;
            this.btnXFecha.Text = "Filtrar x Fecha";
            this.btnXFecha.UseVisualStyleBackColor = true;
            // 
            // btnXDocumentacion
            // 
            this.btnXDocumentacion.Location = new System.Drawing.Point(177, 13);
            this.btnXDocumentacion.Name = "btnXDocumentacion";
            this.btnXDocumentacion.Size = new System.Drawing.Size(91, 40);
            this.btnXDocumentacion.TabIndex = 15;
            this.btnXDocumentacion.Text = "Resumen x Documentacion";
            this.btnXDocumentacion.UseVisualStyleBackColor = true;
            // 
            // btnXMes
            // 
            this.btnXMes.Location = new System.Drawing.Point(95, 13);
            this.btnXMes.Name = "btnXMes";
            this.btnXMes.Size = new System.Drawing.Size(75, 40);
            this.btnXMes.TabIndex = 14;
            this.btnXMes.Text = "Resumen Mensual";
            this.btnXMes.UseVisualStyleBackColor = true;
            // 
            // btnXTramite
            // 
            this.btnXTramite.Location = new System.Drawing.Point(13, 13);
            this.btnXTramite.Name = "btnXTramite";
            this.btnXTramite.Size = new System.Drawing.Size(75, 40);
            this.btnXTramite.TabIndex = 13;
            this.btnXTramite.Text = "Resumen x Tramite";
            this.btnXTramite.UseVisualStyleBackColor = true;
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 73);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.Size = new System.Drawing.Size(719, 391);
            this.dgvSolicitudes.TabIndex = 12;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(274, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(139, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(497, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "DD/MM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Seleccione una fecha:";
            // 
            // ddlMes
            // 
            this.ddlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMes.FormattingEnabled = true;
            this.ddlMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.ddlMes.Location = new System.Drawing.Point(458, 32);
            this.ddlMes.Name = "ddlMes";
            this.ddlMes.Size = new System.Drawing.Size(33, 21);
            this.ddlMes.TabIndex = 20;
            // 
            // ddlDia
            // 
            this.ddlDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDia.FormattingEnabled = true;
            this.ddlDia.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.ddlDia.Location = new System.Drawing.Point(419, 32);
            this.ddlDia.Name = "ddlDia";
            this.ddlDia.Size = new System.Drawing.Size(33, 21);
            this.ddlDia.TabIndex = 19;
            // 
            // frmListadoSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 550);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnXFecha);
            this.Controls.Add(this.btnXDocumentacion);
            this.Controls.Add(this.btnXMes);
            this.Controls.Add(this.btnXTramite);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlMes);
            this.Controls.Add(this.ddlDia);
            this.Name = "frmListadoSolicitudes";
            this.Text = "frmListadoSolicitudes";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnXFecha;
        private System.Windows.Forms.Button btnXDocumentacion;
        private System.Windows.Forms.Button btnXMes;
        private System.Windows.Forms.Button btnXTramite;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlMes;
        private System.Windows.Forms.ComboBox ddlDia;
    }
}