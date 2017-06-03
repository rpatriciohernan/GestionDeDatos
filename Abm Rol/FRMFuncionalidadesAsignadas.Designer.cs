namespace UberFrba.Abm_Rol
{
    partial class FRMFuncionalidadesAsignadas
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
            this.label19 = new System.Windows.Forms.Label();
            this.BTNeliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNagregar = new System.Windows.Forms.Button();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNterminar = new System.Windows.Forms.Button();
            this.CMBfuncionalidad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(9, 47);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(176, 16);
            this.label19.TabIndex = 54;
            this.label19.Text = "Funcionalidades Asignadas";
            // 
            // BTNeliminar
            // 
            this.BTNeliminar.Location = new System.Drawing.Point(152, 254);
            this.BTNeliminar.Name = "BTNeliminar";
            this.BTNeliminar.Size = new System.Drawing.Size(112, 23);
            this.BTNeliminar.TabIndex = 53;
            this.BTNeliminar.Text = "ELIMINAR";
            this.BTNeliminar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(252, 118);
            this.dataGridView1.TabIndex = 52;
            // 
            // BTNagregar
            // 
            this.BTNagregar.Location = new System.Drawing.Point(12, 254);
            this.BTNagregar.Name = "BTNagregar";
            this.BTNagregar.Size = new System.Drawing.Size(108, 23);
            this.BTNagregar.TabIndex = 51;
            this.BTNagregar.Text = "AGREGAR";
            this.BTNagregar.UseVisualStyleBackColor = true;
            // 
            // TXTnombre
            // 
            this.TXTnombre.Enabled = false;
            this.TXTnombre.Location = new System.Drawing.Point(12, 24);
            this.TXTnombre.Margin = new System.Windows.Forms.Padding(4);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(252, 20);
            this.TXTnombre.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(10, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "Rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(13, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Funcionalidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BTNterminar
            // 
            this.BTNterminar.Location = new System.Drawing.Point(12, 284);
            this.BTNterminar.Name = "BTNterminar";
            this.BTNterminar.Size = new System.Drawing.Size(250, 23);
            this.BTNterminar.TabIndex = 57;
            this.BTNterminar.Text = "TERMINAR";
            this.BTNterminar.UseVisualStyleBackColor = true;
            this.BTNterminar.Click += new System.EventHandler(this.BTNterminar_Click);
            // 
            // CMBfuncionalidad
            // 
            this.CMBfuncionalidad.FormattingEnabled = true;
            this.CMBfuncionalidad.Location = new System.Drawing.Point(12, 218);
            this.CMBfuncionalidad.Name = "CMBfuncionalidad";
            this.CMBfuncionalidad.Size = new System.Drawing.Size(250, 21);
            this.CMBfuncionalidad.TabIndex = 58;
            // 
            // FRMFuncionalidadesAsignadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 317);
            this.Controls.Add(this.CMBfuncionalidad);
            this.Controls.Add(this.BTNterminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.BTNeliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNagregar);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label2);
            this.Name = "FRMFuncionalidadesAsignadas";
            this.Text = "Funcionalidades Asignadas";
            this.Load += new System.EventHandler(this.FRMFuncionalidadesAsignadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button BTNeliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNagregar;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNterminar;
        private System.Windows.Forms.ComboBox CMBfuncionalidad;
    }
}