namespace UberFrba.Abm_Funcionalidad
{
    partial class FRMBuscarFuncionalidad
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNbuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNnuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label19.Location = new System.Drawing.Point(13, 113);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 16);
            this.label19.TabIndex = 48;
            this.label19.Text = "Resultados de busqueda";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(519, 151);
            this.dataGridView1.TabIndex = 46;
            // 
            // BTNbuscar
            // 
            this.BTNbuscar.Location = new System.Drawing.Point(18, 87);
            this.BTNbuscar.Name = "BTNbuscar";
            this.BTNbuscar.Size = new System.Drawing.Size(252, 23);
            this.BTNbuscar.TabIndex = 45;
            this.BTNbuscar.Text = "BUSCAR";
            this.BTNbuscar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(14, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "Funcionalidad";
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(18, 60);
            this.TXTnombre.Margin = new System.Windows.Forms.Padding(4);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(518, 20);
            this.TXTnombre.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nombre";
            // 
            // BTNnuevo
            // 
            this.BTNnuevo.Location = new System.Drawing.Point(286, 87);
            this.BTNnuevo.Name = "BTNnuevo";
            this.BTNnuevo.Size = new System.Drawing.Size(251, 23);
            this.BTNnuevo.TabIndex = 52;
            this.BTNnuevo.Text = "CARGAR NUEVO";
            this.BTNnuevo.UseVisualStyleBackColor = true;
            // 
            // FRMBuscarFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 295);
            this.Controls.Add(this.BTNnuevo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNbuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label2);
            this.Name = "FRMBuscarFuncionalidad";
            this.Text = "Funcionalidad";
            this.Load += new System.EventHandler(this.FRMBuscarFuncionalidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNbuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNnuevo;
    }
}