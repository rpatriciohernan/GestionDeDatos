namespace UberFrba.Abm_Rol
{
    partial class FRMRol
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
            this.BTNeliminar = new System.Windows.Forms.Button();
            this.BTNguardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CMBestado = new System.Windows.Forms.ComboBox();
            this.BTNFuncionalidades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTNeliminar
            // 
            this.BTNeliminar.Location = new System.Drawing.Point(138, 153);
            this.BTNeliminar.Name = "BTNeliminar";
            this.BTNeliminar.Size = new System.Drawing.Size(126, 23);
            this.BTNeliminar.TabIndex = 47;
            this.BTNeliminar.Text = "ELIMINAR";
            this.BTNeliminar.UseVisualStyleBackColor = true;
            this.BTNeliminar.Click += new System.EventHandler(this.BTNeliminar_Click);
            // 
            // BTNguardar
            // 
            this.BTNguardar.Location = new System.Drawing.Point(12, 153);
            this.BTNguardar.Name = "BTNguardar";
            this.BTNguardar.Size = new System.Drawing.Size(120, 23);
            this.BTNguardar.TabIndex = 44;
            this.BTNguardar.Text = "GUARDAR";
            this.BTNguardar.UseVisualStyleBackColor = true;
            this.BTNguardar.Click += new System.EventHandler(this.BTNguardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "Gestion de Roles";
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(12, 53);
            this.TXTnombre.Margin = new System.Windows.Forms.Padding(4);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(252, 20);
            this.TXTnombre.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "Estado";
            // 
            // CMBestado
            // 
            this.CMBestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBestado.FormattingEnabled = true;
            this.CMBestado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.CMBestado.Location = new System.Drawing.Point(13, 97);
            this.CMBestado.Name = "CMBestado";
            this.CMBestado.Size = new System.Drawing.Size(251, 21);
            this.CMBestado.TabIndex = 50;
            // 
            // BTNFuncionalidades
            // 
            this.BTNFuncionalidades.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNFuncionalidades.Location = new System.Drawing.Point(13, 128);
            this.BTNFuncionalidades.Name = "BTNFuncionalidades";
            this.BTNFuncionalidades.Size = new System.Drawing.Size(251, 23);
            this.BTNFuncionalidades.TabIndex = 51;
            this.BTNFuncionalidades.Text = "FUNCIONALIDADES";
            this.BTNFuncionalidades.UseVisualStyleBackColor = true;
            this.BTNFuncionalidades.Click += new System.EventHandler(this.BTNFuncionalidades_Click);
            // 
            // FRMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 187);
            this.Controls.Add(this.BTNFuncionalidades);
            this.Controls.Add(this.CMBestado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTNeliminar);
            this.Controls.Add(this.BTNguardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label2);
            this.Name = "FRMRol";
            this.Text = "Rol";
            this.Load += new System.EventHandler(this.FRMRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNeliminar;
        private System.Windows.Forms.Button BTNguardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMBestado;
        private System.Windows.Forms.Button BTNFuncionalidades;

    }
}