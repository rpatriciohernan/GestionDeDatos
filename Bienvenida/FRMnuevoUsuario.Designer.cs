namespace UberFrba.Bienvenida
{
    partial class FRMnuevoUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.TXTuserName = new System.Windows.Forms.TextBox();
            this.TXTpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTdni = new System.Windows.Forms.TextBox();
            this.BTNSoyChofer = new System.Windows.Forms.Button();
            this.BTNSoyCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNactivar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Alta de usuario";
            // 
            // TXTuserName
            // 
            this.TXTuserName.Location = new System.Drawing.Point(12, 53);
            this.TXTuserName.Name = "TXTuserName";
            this.TXTuserName.Size = new System.Drawing.Size(260, 20);
            this.TXTuserName.TabIndex = 45;
            // 
            // TXTpassword
            // 
            this.TXTpassword.Location = new System.Drawing.Point(12, 98);
            this.TXTpassword.Name = "TXTpassword";
            this.TXTpassword.PasswordChar = '*';
            this.TXTpassword.Size = new System.Drawing.Size(260, 20);
            this.TXTpassword.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nombre de Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Contrasena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "DNI";
            // 
            // TXTdni
            // 
            this.TXTdni.Location = new System.Drawing.Point(14, 144);
            this.TXTdni.Name = "TXTdni";
            this.TXTdni.Size = new System.Drawing.Size(260, 20);
            this.TXTdni.TabIndex = 49;
            // 
            // BTNSoyChofer
            // 
            this.BTNSoyChofer.Location = new System.Drawing.Point(12, 197);
            this.BTNSoyChofer.Name = "BTNSoyChofer";
            this.BTNSoyChofer.Size = new System.Drawing.Size(125, 42);
            this.BTNSoyChofer.TabIndex = 51;
            this.BTNSoyChofer.Text = "SOY CHOFER";
            this.BTNSoyChofer.UseVisualStyleBackColor = true;
            this.BTNSoyChofer.Click += new System.EventHandler(this.BTNSoyChofer_Click);
            // 
            // BTNSoyCliente
            // 
            this.BTNSoyCliente.Location = new System.Drawing.Point(151, 197);
            this.BTNSoyCliente.Name = "BTNSoyCliente";
            this.BTNSoyCliente.Size = new System.Drawing.Size(121, 42);
            this.BTNSoyCliente.TabIndex = 52;
            this.BTNSoyCliente.Text = "SOY CLIENTE";
            this.BTNSoyCliente.UseVisualStyleBackColor = true;
            this.BTNSoyCliente.Click += new System.EventHandler(this.BTNSoyCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(11, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "Completa tus datos segun corresponda";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // BTNactivar
            // 
            this.BTNactivar.Location = new System.Drawing.Point(14, 252);
            this.BTNactivar.Name = "BTNactivar";
            this.BTNactivar.Size = new System.Drawing.Size(258, 42);
            this.BTNactivar.TabIndex = 54;
            this.BTNactivar.Text = "ACTIVAR";
            this.BTNactivar.UseVisualStyleBackColor = true;
            this.BTNactivar.Click += new System.EventHandler(this.BTNactivar_Click);
            // 
            // FRMnuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 306);
            this.Controls.Add(this.BTNactivar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTNSoyCliente);
            this.Controls.Add(this.BTNSoyChofer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTdni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXTpassword);
            this.Controls.Add(this.TXTuserName);
            this.Controls.Add(this.label1);
            this.Name = "FRMnuevoUsuario";
            this.Text = "Alta de usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTuserName;
        private System.Windows.Forms.TextBox TXTpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTdni;
        private System.Windows.Forms.Button BTNSoyChofer;
        private System.Windows.Forms.Button BTNSoyCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTNactivar;
    }
}