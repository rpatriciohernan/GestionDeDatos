using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class FRMChofer : Form
    {
        public FRMChofer()
        {
            InitializeComponent();
        }

        String nombre;
        String apellido;
        Int64 dni;
        String domicilio;
        String localidad;
        String telefono;
        String mail;
        DateTime fechaNacimiento;
        String estado;
        Boolean formularioPrecargado = false;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FRMChofer_Load(object sender, EventArgs e)
        {
            this.CMBestado.Items.Add("Activo");
            this.CMBestado.Items.Add("Inactivo");
            if (!formularioPrecargado) { this.CMBestado.Text = "Activo"; } else {
                this.TXTnombre.Text = nombre;
                this.TXTapellido.Text = apellido;
                this.TXTdni.Text = dni.ToString();
                this.TXTdomicilio.Text = domicilio;
                this.TXTlocalidad.Text = localidad;
                this.TXTtelefono.Text = telefono;
                this.TXTmail.Text = mail;
                this.DTEfechaNacimiento.Value= fechaNacimiento;
                this.CMBestado.Text = estado;
            };

        }

        public void recibirDatos(String nombre, String apellido, Int64 dni, String mail, String domicilio, String localidad, String telefono, DateTime fechaNacimiento, String estado) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.domicilio = domicilio;
            this.localidad = localidad;
            this.telefono = telefono;
            this.mail = mail ;
            this.fechaNacimiento = fechaNacimiento;
            this.estado = estado;
            formularioPrecargado = true;
        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTnombre.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTapellido.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTdomicilio.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTdni.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.DTEfechaNacimiento.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTlocalidad.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTtelefono.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTmail.Text)) { validado = false; }

            return validado;

        }


        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                if (formularioPrecargado) { this.crearChofer().modificate(); } else { this.crearChofer().guardate();}
                this.Close();
            }
            else
            {
                this.MensajeError();
            };           
        }

        private Chofer crearChofer()
        {
            return new Chofer(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTdomicilio.Text, 
                TXTlocalidad.Text, TXTtelefono.Text,  TXTmail.Text, Convert.ToDateTime(DTEfechaNacimiento.Text), CMBestado.Text);
        }
    }
}
