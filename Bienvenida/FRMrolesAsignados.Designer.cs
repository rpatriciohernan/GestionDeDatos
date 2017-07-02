namespace UberFrba.Bienvenida
{
    partial class FRMrolesAsignados
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
            this.CMBrol = new System.Windows.Forms.ComboBox();
            this.BTNterminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNagregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTusuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CMBrol
            // 
            this.CMBrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBrol.FormattingEnabled = true;
            this.CMBrol.Location = new System.Drawing.Point(12, 233);
            this.CMBrol.Name = "CMBrol";
            this.CMBrol.Size = new System.Drawing.Size(444, 21);
            this.CMBrol.TabIndex = 67;
            this.CMBrol.SelectedIndexChanged += new System.EventHandler(this.CMBrol_SelectedIndexChanged);
            // 
            // BTNterminar
            // 
            this.BTNterminar.Location = new System.Drawing.Point(12, 299);
            this.BTNterminar.Name = "BTNterminar";
            this.BTNterminar.Size = new System.Drawing.Size(444, 23);
            this.BTNterminar.TabIndex = 66;
            this.BTNterminar.Text = "TERMINAR";
            this.BTNterminar.UseVisualStyleBackColor = true;
            this.BTNterminar.Click += new System.EventHandler(this.BTNterminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(13, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Rol";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(9, 62);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 16);
            this.label19.TabIndex = 64;
            this.label19.Text = "Roles Asignadas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(446, 118);
            this.dataGridView1.TabIndex = 62;
            // 
            // BTNagregar
            // 
            this.BTNagregar.Location = new System.Drawing.Point(12, 269);
            this.BTNagregar.Name = "BTNagregar";
            this.BTNagregar.Size = new System.Drawing.Size(444, 23);
            this.BTNagregar.TabIndex = 61;
            this.BTNagregar.Text = "AGREGAR";
            this.BTNagregar.UseVisualStyleBackColor = true;
            this.BTNagregar.Click += new System.EventHandler(this.BTNagregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Usuario";
            // 
            // TXTusuario
            // 
            this.TXTusuario.Enabled = false;
            this.TXTusuario.Location = new System.Drawing.Point(12, 39);
            this.TXTusuario.Name = "TXTusuario";
            this.TXTusuario.Size = new System.Drawing.Size(446, 20);
            this.TXTusuario.TabIndex = 68;
            // 
            // FRMrolesAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 337);
            this.Controls.Add(this.TXTusuario);
            this.Controls.Add(this.CMBrol);
            this.Controls.Add(this.BTNterminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNagregar);
            this.Controls.Add(this.label2);
            this.Name = "FRMrolesAsignados";
            this.Text = "Roles Asignados";
            this.Load += new System.EventHandler(this.FRMrolesAsignados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMBrol;
        private System.Windows.Forms.Button BTNterminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNagregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTusuario;
    }
}