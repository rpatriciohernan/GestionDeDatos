namespace UberFrba.Bienvenida
{
    partial class FRMlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMlogin));
            this.TXTusername = new System.Windows.Forms.TextBox();
            this.TXTpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNingresar = new System.Windows.Forms.Button();
            this.LBLrol = new System.Windows.Forms.Label();
            this.CMBrolDeAcceso = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBLerrorLogueo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTusername
            // 
            this.TXTusername.Location = new System.Drawing.Point(12, 183);
            this.TXTusername.Name = "TXTusername";
            this.TXTusername.Size = new System.Drawing.Size(254, 20);
            this.TXTusername.TabIndex = 0;
            // 
            // TXTpassword
            // 
            this.TXTpassword.Location = new System.Drawing.Point(12, 245);
            this.TXTpassword.Name = "TXTpassword";
            this.TXTpassword.PasswordChar = '*';
            this.TXTpassword.Size = new System.Drawing.Size(254, 20);
            this.TXTpassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "CONTRASENA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "USUARIO";
            // 
            // BTNingresar
            // 
            this.BTNingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNingresar.Location = new System.Drawing.Point(12, 379);
            this.BTNingresar.Name = "BTNingresar";
            this.BTNingresar.Size = new System.Drawing.Size(254, 28);
            this.BTNingresar.TabIndex = 5;
            this.BTNingresar.Text = "INGRESAR";
            this.BTNingresar.UseVisualStyleBackColor = true;
            this.BTNingresar.Visible = false;
            this.BTNingresar.Click += new System.EventHandler(this.BTNingresar_Click);
            // 
            // LBLrol
            // 
            this.LBLrol.AutoSize = true;
            this.LBLrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLrol.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LBLrol.Location = new System.Drawing.Point(12, 325);
            this.LBLrol.Name = "LBLrol";
            this.LBLrol.Size = new System.Drawing.Size(153, 20);
            this.LBLrol.TabIndex = 7;
            this.LBLrol.Text = "ROL DE ACCESO";
            this.LBLrol.Visible = false;
            // 
            // CMBrolDeAcceso
            // 
            this.CMBrolDeAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBrolDeAcceso.FormattingEnabled = true;
            this.CMBrolDeAcceso.Location = new System.Drawing.Point(13, 348);
            this.CMBrolDeAcceso.Name = "CMBrolDeAcceso";
            this.CMBrolDeAcceso.Size = new System.Drawing.Size(253, 21);
            this.CMBrolDeAcceso.TabIndex = 8;
            this.CMBrolDeAcceso.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "CONECTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // LBLerrorLogueo
            // 
            this.LBLerrorLogueo.AutoSize = true;
            this.LBLerrorLogueo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLerrorLogueo.ForeColor = System.Drawing.Color.Red;
            this.LBLerrorLogueo.Location = new System.Drawing.Point(47, 302);
            this.LBLerrorLogueo.Name = "LBLerrorLogueo";
            this.LBLerrorLogueo.Size = new System.Drawing.Size(188, 20);
            this.LBLerrorLogueo.TabIndex = 11;
            this.LBLerrorLogueo.Text = "ACCESO DENEGADO";
            this.LBLerrorLogueo.Visible = false;
            // 
            // FRMlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(278, 416);
            this.Controls.Add(this.LBLerrorLogueo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CMBrolDeAcceso);
            this.Controls.Add(this.LBLrol);
            this.Controls.Add(this.BTNingresar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTpassword);
            this.Controls.Add(this.TXTusername);
            this.Name = "FRMlogin";
            this.Text = "UBER UTN FRBA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTusername;
        private System.Windows.Forms.TextBox TXTpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNingresar;
        private System.Windows.Forms.Label LBLrol;
        private System.Windows.Forms.ComboBox CMBrolDeAcceso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBLerrorLogueo;
    }
}