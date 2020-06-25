namespace BackOfficeTramites
{
    partial class frmSolicitud
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
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnRechazada = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.LblError = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(122, 12);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(149, 23);
            this.btnEjecutar.TabIndex = 71;
            this.btnEjecutar.Text = "Marcar como ejecutada";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click_1);
            // 
            // btnRechazada
            // 
            this.btnRechazada.Location = new System.Drawing.Point(277, 12);
            this.btnRechazada.Name = "btnRechazada";
            this.btnRechazada.Size = new System.Drawing.Size(152, 23);
            this.btnRechazada.TabIndex = 72;
            this.btnRechazada.Text = "Marcar como anulada";
            this.btnRechazada.UseVisualStyleBackColor = true;
            this.btnRechazada.Click += new System.EventHandler(this.btnRechazada_Click_1);
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AllowUserToOrderColumns = true;
            this.dgvSolicitudes.AllowUserToResizeColumns = false;
            this.dgvSolicitudes.AllowUserToResizeRows = false;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 71);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.Size = new System.Drawing.Size(560, 465);
            this.dgvSolicitudes.TabIndex = 73;
            // 
            // BarraEstado
            // 
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblError});
            this.BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.BarraEstado.TabIndex = 74;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // LblError
            // 
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(0, 17);
            // 
            // frmSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.btnRechazada);
            this.Controls.Add(this.btnEjecutar);
            this.Name = "frmSolicitud";
            this.Text = "frmSolicitud";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnRechazada;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel LblError;
    }
}