namespace UberFrba.Registro_Viajes
{
    partial class FRMviajesRegistrados
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNbuscar = new System.Windows.Forms.Button();
            this.RBTtipoChofer = new System.Windows.Forms.RadioButton();
            this.RBTtipoCliente = new System.Windows.Forms.RadioButton();
            this.TXTdni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(468, 234);
            this.dataGridView1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(13, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "Viajes registrados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 45);
            this.label1.TabIndex = 79;
            this.label1.Text = "Registro de Viaje";
            // 
            // BTNbuscar
            // 
            this.BTNbuscar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BTNbuscar.Location = new System.Drawing.Point(10, 97);
            this.BTNbuscar.Name = "BTNbuscar";
            this.BTNbuscar.Size = new System.Drawing.Size(470, 23);
            this.BTNbuscar.TabIndex = 80;
            this.BTNbuscar.Text = "BUSCAR";
            this.BTNbuscar.UseVisualStyleBackColor = true;
            this.BTNbuscar.Click += new System.EventHandler(this.BTNbuscar_Click);
            // 
            // RBTtipoChofer
            // 
            this.RBTtipoChofer.AutoSize = true;
            this.RBTtipoChofer.Location = new System.Drawing.Point(299, 67);
            this.RBTtipoChofer.Name = "RBTtipoChofer";
            this.RBTtipoChofer.Size = new System.Drawing.Size(56, 17);
            this.RBTtipoChofer.TabIndex = 81;
            this.RBTtipoChofer.TabStop = true;
            this.RBTtipoChofer.Text = "Chofer";
            this.RBTtipoChofer.UseVisualStyleBackColor = true;
            // 
            // RBTtipoCliente
            // 
            this.RBTtipoCliente.AutoSize = true;
            this.RBTtipoCliente.Location = new System.Drawing.Point(381, 67);
            this.RBTtipoCliente.Name = "RBTtipoCliente";
            this.RBTtipoCliente.Size = new System.Drawing.Size(57, 17);
            this.RBTtipoCliente.TabIndex = 82;
            this.RBTtipoCliente.TabStop = true;
            this.RBTtipoCliente.Text = "Cliente";
            this.RBTtipoCliente.UseVisualStyleBackColor = true;
            // 
            // TXTdni
            // 
            this.TXTdni.Location = new System.Drawing.Point(10, 67);
            this.TXTdni.Name = "TXTdni";
            this.TXTdni.Size = new System.Drawing.Size(253, 20);
            this.TXTdni.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 16);
            this.label3.TabIndex = 84;
            this.label3.Text = "Indique DNI y tipo de busqueda";
            // 
            // FRMviajesRegistrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 398);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTdni);
            this.Controls.Add(this.RBTtipoCliente);
            this.Controls.Add(this.RBTtipoChofer);
            this.Controls.Add(this.BTNbuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FRMviajesRegistrados";
            this.Text = "Mis viajes registrados";
            this.Load += new System.EventHandler(this.FRMviajesRegistrados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNbuscar;
        private System.Windows.Forms.RadioButton RBTtipoChofer;
        private System.Windows.Forms.RadioButton RBTtipoCliente;
        private System.Windows.Forms.TextBox TXTdni;
        private System.Windows.Forms.Label label3;
    }
}