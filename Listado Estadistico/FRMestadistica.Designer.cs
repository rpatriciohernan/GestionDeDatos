namespace UberFrba.Listado_Estadistico
{
    partial class FRMestadistica
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
            this.BTNchoferMayorRecaudacion = new System.Windows.Forms.Button();
            this.BTNchoferViajeLargo = new System.Windows.Forms.Button();
            this.BTNclienteConsumo = new System.Windows.Forms.Button();
            this.BTNclienteUsoMismoAutomovil = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CMBtrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTanio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNchoferMayorRecaudacion
            // 
            this.BTNchoferMayorRecaudacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNchoferMayorRecaudacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNchoferMayorRecaudacion.Location = new System.Drawing.Point(12, 139);
            this.BTNchoferMayorRecaudacion.Name = "BTNchoferMayorRecaudacion";
            this.BTNchoferMayorRecaudacion.Size = new System.Drawing.Size(118, 62);
            this.BTNchoferMayorRecaudacion.TabIndex = 0;
            this.BTNchoferMayorRecaudacion.Text = "CHOFERES CON MAYOR RECAUDACION";
            this.BTNchoferMayorRecaudacion.UseVisualStyleBackColor = false;
            this.BTNchoferMayorRecaudacion.Click += new System.EventHandler(this.BTNchoferMayorRecaudacion_Click);
            // 
            // BTNchoferViajeLargo
            // 
            this.BTNchoferViajeLargo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNchoferViajeLargo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNchoferViajeLargo.Location = new System.Drawing.Point(135, 139);
            this.BTNchoferViajeLargo.Name = "BTNchoferViajeLargo";
            this.BTNchoferViajeLargo.Size = new System.Drawing.Size(118, 62);
            this.BTNchoferViajeLargo.TabIndex = 1;
            this.BTNchoferViajeLargo.Text = "CHOFERES CON VIAJES MAS LARGOS";
            this.BTNchoferViajeLargo.UseVisualStyleBackColor = false;
            this.BTNchoferViajeLargo.Click += new System.EventHandler(this.BTNchoferViajeLargo_Click);
            // 
            // BTNclienteConsumo
            // 
            this.BTNclienteConsumo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNclienteConsumo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNclienteConsumo.Location = new System.Drawing.Point(259, 139);
            this.BTNclienteConsumo.Name = "BTNclienteConsumo";
            this.BTNclienteConsumo.Size = new System.Drawing.Size(118, 62);
            this.BTNclienteConsumo.TabIndex = 2;
            this.BTNclienteConsumo.Text = "CLIENTES CON MAYOR CONSUMO";
            this.BTNclienteConsumo.UseVisualStyleBackColor = false;
            this.BTNclienteConsumo.Click += new System.EventHandler(this.BTNclienteConsumo_Click);
            // 
            // BTNclienteUsoMismoAutomovil
            // 
            this.BTNclienteUsoMismoAutomovil.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNclienteUsoMismoAutomovil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTNclienteUsoMismoAutomovil.Location = new System.Drawing.Point(383, 139);
            this.BTNclienteUsoMismoAutomovil.Name = "BTNclienteUsoMismoAutomovil";
            this.BTNclienteUsoMismoAutomovil.Size = new System.Drawing.Size(118, 62);
            this.BTNclienteUsoMismoAutomovil.TabIndex = 3;
            this.BTNclienteUsoMismoAutomovil.Text = "CLIENTE CON MAYOR USO DE AUTOMOVIL";
            this.BTNclienteUsoMismoAutomovil.UseVisualStyleBackColor = false;
            this.BTNclienteUsoMismoAutomovil.Click += new System.EventHandler(this.BTNclienteUsoMismoAutomovil_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(489, 193);
            this.dataGridView1.TabIndex = 36;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(9, 217);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 16);
            this.label19.TabIndex = 37;
            this.label19.Text = "Reporte Consolidado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Seleccione el tipo de reporte a elegir para obtener el TOP 5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Trimestre";
            // 
            // CMBtrimestre
            // 
            this.CMBtrimestre.FormattingEnabled = true;
            this.CMBtrimestre.Items.AddRange(new object[] {
            "1: Primer Trimestre",
            "2: Segundo Trimestre",
            "3: Tercer Trimestre",
            "4: Cuarto Trimestre"});
            this.CMBtrimestre.Location = new System.Drawing.Point(12, 84);
            this.CMBtrimestre.Name = "CMBtrimestre";
            this.CMBtrimestre.Size = new System.Drawing.Size(226, 21);
            this.CMBtrimestre.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(258, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Año";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TXTanio
            // 
            this.TXTanio.Location = new System.Drawing.Point(261, 84);
            this.TXTanio.Name = "TXTanio";
            this.TXTanio.Size = new System.Drawing.Size(168, 20);
            this.TXTanio.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 45);
            this.label4.TabIndex = 43;
            this.label4.Text = "Modulo de Estadistica";
            // 
            // FRMestadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 454);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTanio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CMBtrimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.BTNclienteUsoMismoAutomovil);
            this.Controls.Add(this.BTNclienteConsumo);
            this.Controls.Add(this.BTNchoferViajeLargo);
            this.Controls.Add(this.BTNchoferMayorRecaudacion);
            this.Name = "FRMestadistica";
            this.Text = "Modulo Estadistica";
            this.Load += new System.EventHandler(this.FRMestadistica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNchoferMayorRecaudacion;
        private System.Windows.Forms.Button BTNchoferViajeLargo;
        private System.Windows.Forms.Button BTNclienteConsumo;
        private System.Windows.Forms.Button BTNclienteUsoMismoAutomovil;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMBtrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTanio;
        private System.Windows.Forms.Label label4;
    }
}