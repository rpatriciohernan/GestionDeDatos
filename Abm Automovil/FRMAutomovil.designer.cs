namespace UberFrba.Abm_Automovil
{
    partial class FRMAutomovil

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNnuevaMarca = new System.Windows.Forms.Button();
            this.CMBturno = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CMBmarca = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BTNpatente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.BTNeliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNbuscar = new System.Windows.Forms.Button();
            this.BTNguardar = new System.Windows.Forms.Button();
            this.CMBestado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BTNChofer = new System.Windows.Forms.ComboBox();
            this.TXTmodelo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXTmodelo);
            this.groupBox1.Controls.Add(this.BTNnuevaMarca);
            this.groupBox1.Controls.Add(this.CMBturno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CMBmarca);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.BTNpatente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 81);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del vehiculo";
            // 
            // BTNnuevaMarca
            // 
            this.BTNnuevaMarca.Location = new System.Drawing.Point(284, 47);
            this.BTNnuevaMarca.Name = "BTNnuevaMarca";
            this.BTNnuevaMarca.Size = new System.Drawing.Size(18, 23);
            this.BTNnuevaMarca.TabIndex = 33;
            this.BTNnuevaMarca.Text = "+";
            this.BTNnuevaMarca.UseVisualStyleBackColor = true;
            this.BTNnuevaMarca.Click += new System.EventHandler(this.button4_Click);
            // 
            // CMBturno
            // 
            this.CMBturno.FormattingEnabled = true;
            this.CMBturno.Location = new System.Drawing.Point(485, 48);
            this.CMBturno.Name = "CMBturno";
            this.CMBturno.Size = new System.Drawing.Size(65, 21);
            this.CMBturno.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(482, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Turno";
            // 
            // CMBmarca
            // 
            this.CMBmarca.FormattingEnabled = true;
            this.CMBmarca.Location = new System.Drawing.Point(131, 49);
            this.CMBmarca.Name = "CMBmarca";
            this.CMBmarca.Size = new System.Drawing.Size(152, 21);
            this.CMBmarca.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(303, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 26;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(171, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(61, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 18);
            this.label12.TabIndex = 24;
            this.label12.Text = "*";
            // 
            // BTNpatente
            // 
            this.BTNpatente.Location = new System.Drawing.Point(11, 49);
            this.BTNpatente.Margin = new System.Windows.Forms.Padding(4);
            this.BTNpatente.Name = "BTNpatente";
            this.BTNpatente.Size = new System.Drawing.Size(116, 20);
            this.BTNpatente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Patente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(128, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Marca";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(304, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Modelo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 45);
            this.label1.TabIndex = 20;
            this.label1.Text = "Gestion de Vehiculos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(9, 257);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 16);
            this.label19.TabIndex = 31;
            this.label19.Text = "Resultados de busqueda";
            // 
            // BTNeliminar
            // 
            this.BTNeliminar.Location = new System.Drawing.Point(396, 223);
            this.BTNeliminar.Name = "BTNeliminar";
            this.BTNeliminar.Size = new System.Drawing.Size(170, 23);
            this.BTNeliminar.TabIndex = 30;
            this.BTNeliminar.Text = "ELIMINAR";
            this.BTNeliminar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(557, 239);
            this.dataGridView1.TabIndex = 29;
            // 
            // BTNbuscar
            // 
            this.BTNbuscar.Location = new System.Drawing.Point(199, 223);
            this.BTNbuscar.Name = "BTNbuscar";
            this.BTNbuscar.Size = new System.Drawing.Size(189, 23);
            this.BTNbuscar.TabIndex = 28;
            this.BTNbuscar.Text = "BUSCAR";
            this.BTNbuscar.UseVisualStyleBackColor = true;
            // 
            // BTNguardar
            // 
            this.BTNguardar.Location = new System.Drawing.Point(14, 223);
            this.BTNguardar.Name = "BTNguardar";
            this.BTNguardar.Size = new System.Drawing.Size(174, 23);
            this.BTNguardar.TabIndex = 27;
            this.BTNguardar.Text = "GUARDAR";
            this.BTNguardar.UseVisualStyleBackColor = true;
            // 
            // CMBestado
            // 
            this.CMBestado.FormattingEnabled = true;
            this.CMBestado.Location = new System.Drawing.Point(14, 181);
            this.CMBestado.Name = "CMBestado";
            this.CMBestado.Size = new System.Drawing.Size(174, 21);
            this.CMBestado.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(13, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Estado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(198, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Chofer Asignado";
            // 
            // BTNChofer
            // 
            this.BTNChofer.FormattingEnabled = true;
            this.BTNChofer.Location = new System.Drawing.Point(199, 181);
            this.BTNChofer.Name = "BTNChofer";
            this.BTNChofer.Size = new System.Drawing.Size(364, 21);
            this.BTNChofer.TabIndex = 34;
            // 
            // TXTmodelo
            // 
            this.TXTmodelo.Location = new System.Drawing.Point(309, 49);
            this.TXTmodelo.Name = "TXTmodelo";
            this.TXTmodelo.Size = new System.Drawing.Size(170, 20);
            this.TXTmodelo.TabIndex = 34;
            // 
            // FRMAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 529);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BTNChofer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMBestado);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BTNeliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNbuscar);
            this.Controls.Add(this.BTNguardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FRMAutomovil";
            this.Text = "Vehiculo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox BTNpatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNnuevaMarca;
        private System.Windows.Forms.ComboBox CMBturno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CMBmarca;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button BTNeliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNbuscar;
        private System.Windows.Forms.Button BTNguardar;
        private System.Windows.Forms.ComboBox CMBestado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox BTNChofer;
        private System.Windows.Forms.TextBox TXTmodelo;
    }
}