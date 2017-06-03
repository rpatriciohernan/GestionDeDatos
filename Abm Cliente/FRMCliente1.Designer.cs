namespace UberFrba.Abm_Cliente
{
    partial class FRMCliente1
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblNombreError = new System.Windows.Forms.Label();
            this.lblApellidoError = new System.Windows.Forms.Label();
            this.lblDniError = new System.Windows.Forms.Label();
            this.lblMailError = new System.Windows.Forms.Label();
            this.lblTelefonoError = new System.Windows.Forms.Label();
            this.lblDireccionError = new System.Windows.Forms.Label();
            this.lblCodigoPostalError = new System.Windows.Forms.Label();
            this.lblFechaNacimientoError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(3, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Location = new System.Drawing.Point(358, 149);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(100, 20);
            this.txtFechaNacimiento.TabIndex = 7;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(243, 149);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPostal.TabIndex = 6;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(123, 149);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(3, 149);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 4;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(358, 75);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 3;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(243, 75);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 2;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(123, 75);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(240, 133);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(72, 13);
            this.lblCodigoPostal.TabIndex = 8;
            this.lblCodigoPostal.Text = "Codigo Postal";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(0, 59);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(120, 61);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 10;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(240, 59);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 11;
            this.lblDNI.Text = "DNI";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(355, 59);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 12;
            this.lblMail.Text = "Mail";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(0, 133);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(120, 133);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 14;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(355, 133);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(106, 13);
            this.lblFechaNacimiento.TabIndex = 15;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(383, 210);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(302, 210);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(455, 150);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblNombreError
            // 
            this.lblNombreError.AutoSize = true;
            this.lblNombreError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNombreError.Location = new System.Drawing.Point(0, 98);
            this.lblNombreError.Name = "lblNombreError";
            this.lblNombreError.Size = new System.Drawing.Size(0, 13);
            this.lblNombreError.TabIndex = 17;
            this.lblNombreError.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblApellidoError
            // 
            this.lblApellidoError.AutoSize = true;
            this.lblApellidoError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblApellidoError.Location = new System.Drawing.Point(120, 98);
            this.lblApellidoError.Name = "lblApellidoError";
            this.lblApellidoError.Size = new System.Drawing.Size(0, 13);
            this.lblApellidoError.TabIndex = 18;
            // 
            // lblDniError
            // 
            this.lblDniError.AutoSize = true;
            this.lblDniError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDniError.Location = new System.Drawing.Point(240, 98);
            this.lblDniError.Name = "lblDniError";
            this.lblDniError.Size = new System.Drawing.Size(0, 13);
            this.lblDniError.TabIndex = 19;
            // 
            // lblMailError
            // 
            this.lblMailError.AutoSize = true;
            this.lblMailError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMailError.Location = new System.Drawing.Point(355, 98);
            this.lblMailError.Name = "lblMailError";
            this.lblMailError.Size = new System.Drawing.Size(0, 13);
            this.lblMailError.TabIndex = 20;
            // 
            // lblTelefonoError
            // 
            this.lblTelefonoError.AutoSize = true;
            this.lblTelefonoError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTelefonoError.Location = new System.Drawing.Point(0, 172);
            this.lblTelefonoError.Name = "lblTelefonoError";
            this.lblTelefonoError.Size = new System.Drawing.Size(0, 13);
            this.lblTelefonoError.TabIndex = 21;
            // 
            // lblDireccionError
            // 
            this.lblDireccionError.AutoSize = true;
            this.lblDireccionError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDireccionError.Location = new System.Drawing.Point(120, 172);
            this.lblDireccionError.Name = "lblDireccionError";
            this.lblDireccionError.Size = new System.Drawing.Size(0, 13);
            this.lblDireccionError.TabIndex = 22;
            // 
            // lblCodigoPostalError
            // 
            this.lblCodigoPostalError.AutoSize = true;
            this.lblCodigoPostalError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCodigoPostalError.Location = new System.Drawing.Point(240, 172);
            this.lblCodigoPostalError.Name = "lblCodigoPostalError";
            this.lblCodigoPostalError.Size = new System.Drawing.Size(0, 13);
            this.lblCodigoPostalError.TabIndex = 23;
            // 
            // lblFechaNacimientoError
            // 
            this.lblFechaNacimientoError.AutoSize = true;
            this.lblFechaNacimientoError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFechaNacimientoError.Location = new System.Drawing.Point(355, 172);
            this.lblFechaNacimientoError.Name = "lblFechaNacimientoError";
            this.lblFechaNacimientoError.Size = new System.Drawing.Size(0, 13);
            this.lblFechaNacimientoError.TabIndex = 24;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 413);
            this.Controls.Add(this.lblFechaNacimientoError);
            this.Controls.Add(this.lblCodigoPostalError);
            this.Controls.Add(this.lblDireccionError);
            this.Controls.Add(this.lblTelefonoError);
            this.Controls.Add(this.lblMailError);
            this.Controls.Add(this.lblDniError);
            this.Controls.Add(this.lblApellidoError);
            this.Controls.Add(this.lblNombreError);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.txtFechaNacimiento);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmCliente";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblNombreError;
        private System.Windows.Forms.Label lblApellidoError;
        private System.Windows.Forms.Label lblDniError;
        private System.Windows.Forms.Label lblMailError;
        private System.Windows.Forms.Label lblTelefonoError;
        private System.Windows.Forms.Label lblDireccionError;
        private System.Windows.Forms.Label lblCodigoPostalError;
        private System.Windows.Forms.Label lblFechaNacimientoError;

    }
}