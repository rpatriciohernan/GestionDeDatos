namespace UberFrba.Abm_Automovil
{
    partial class FRMbuscarVehiculo
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
            this.CMBChofer = new System.Windows.Forms.ComboBox();
            this.TXTmodelo = new System.Windows.Forms.TextBox();
            this.CMBmarca = new System.Windows.Forms.ComboBox();
            this.TXTpatente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNbuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.CHKsoloActivos = new System.Windows.Forms.CheckBox();
            this.BTNnuevoVehiculo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CMBChofer
            // 
            this.CMBChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBChofer.FormattingEnabled = true;
            this.CMBChofer.Location = new System.Drawing.Point(442, 72);
            this.CMBChofer.Name = "CMBChofer";
            this.CMBChofer.Size = new System.Drawing.Size(170, 21);
            this.CMBChofer.TabIndex = 46;
            // 
            // TXTmodelo
            // 
            this.TXTmodelo.Location = new System.Drawing.Point(295, 73);
            this.TXTmodelo.Name = "TXTmodelo";
            this.TXTmodelo.Size = new System.Drawing.Size(136, 20);
            this.TXTmodelo.TabIndex = 34;
            // 
            // CMBmarca
            // 
            this.CMBmarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBmarca.FormattingEnabled = true;
            this.CMBmarca.Location = new System.Drawing.Point(137, 74);
            this.CMBmarca.Name = "CMBmarca";
            this.CMBmarca.Size = new System.Drawing.Size(152, 21);
            this.CMBmarca.TabIndex = 27;
            // 
            // TXTpatente
            // 
            this.TXTpatente.Location = new System.Drawing.Point(17, 74);
            this.TXTpatente.Margin = new System.Windows.Forms.Padding(4);
            this.TXTpatente.Name = "TXTpatente";
            this.TXTpatente.Size = new System.Drawing.Size(116, 20);
            this.TXTpatente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Patente";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 239);
            this.dataGridView1.TabIndex = 41;
            // 
            // BTNbuscar
            // 
            this.BTNbuscar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BTNbuscar.Location = new System.Drawing.Point(293, 131);
            this.BTNbuscar.Name = "BTNbuscar";
            this.BTNbuscar.Size = new System.Drawing.Size(319, 23);
            this.BTNbuscar.TabIndex = 39;
            this.BTNbuscar.Text = "BUSCAR";
            this.BTNbuscar.UseVisualStyleBackColor = true;
            this.BTNbuscar.Click += new System.EventHandler(this.BTNbuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(134, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Marca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 45);
            this.label1.TabIndex = 35;
            this.label1.Text = "Gestion de Vehiculos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(290, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Modelo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(439, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "Chofer Asignado";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(14, 168);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 16);
            this.label19.TabIndex = 43;
            this.label19.Text = "Resultados de busqueda";
            // 
            // CHKsoloActivos
            // 
            this.CHKsoloActivos.AutoSize = true;
            this.CHKsoloActivos.Checked = true;
            this.CHKsoloActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKsoloActivos.Location = new System.Drawing.Point(18, 101);
            this.CHKsoloActivos.Name = "CHKsoloActivos";
            this.CHKsoloActivos.Size = new System.Drawing.Size(118, 17);
            this.CHKsoloActivos.TabIndex = 47;
            this.CHKsoloActivos.Text = "Buscar solo activos";
            this.CHKsoloActivos.UseVisualStyleBackColor = true;
            // 
            // BTNnuevoVehiculo
            // 
            this.BTNnuevoVehiculo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BTNnuevoVehiculo.Location = new System.Drawing.Point(17, 131);
            this.BTNnuevoVehiculo.Name = "BTNnuevoVehiculo";
            this.BTNnuevoVehiculo.Size = new System.Drawing.Size(272, 23);
            this.BTNnuevoVehiculo.TabIndex = 48;
            this.BTNnuevoVehiculo.Text = "NUEVA CARGA";
            this.BTNnuevoVehiculo.UseVisualStyleBackColor = true;
            this.BTNnuevoVehiculo.Click += new System.EventHandler(this.BTNnuevoVehiculo_Click);
            // 
            // FRMbuscarVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 443);
            this.Controls.Add(this.BTNnuevoVehiculo);
            this.Controls.Add(this.CHKsoloActivos);
            this.Controls.Add(this.TXTmodelo);
            this.Controls.Add(this.CMBChofer);
            this.Controls.Add(this.CMBmarca);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TXTpatente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNbuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label19);
            this.Name = "FRMbuscarVehiculo";
            this.Text = "Buscar Vehiculos";
            this.Load += new System.EventHandler(this.FRMbuscarVehiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMBChofer;
        private System.Windows.Forms.TextBox TXTmodelo;
        private System.Windows.Forms.ComboBox CMBmarca;
        private System.Windows.Forms.TextBox TXTpatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNbuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox CHKsoloActivos;
        private System.Windows.Forms.Button BTNnuevoVehiculo;
    }
}