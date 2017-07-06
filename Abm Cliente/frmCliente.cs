using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class FRMCliente : Form
    {



        public FRMCliente()
        {
            InitializeComponent();
        }


        String nombre;
        String apellido;
        Int64 dni;
        String mail;
        String telefono;
        String domicilio;
        String codigoPostal;
        String localidad;
        DateTime fecha;
        String estado;
        Boolean formularioPrecargado = false;


        private void FRMCliente_Load(object sender, EventArgs e)
        {

            //asociacion de controlador de tipo de datos
            this.TXTtelefono.KeyPress += TXTtelefono_KeyPress;
            this.TXTdni.KeyPress += TXTdni_KeyPress;
            this.CMBestado.Items.Add("Activo");
            this.CMBestado.Items.Add("Inactivo");
            if (!formularioPrecargado) { this.CMBestado.Text = "Activo"; } else { 
                TXTdni.Enabled = false;
                this.TXTnombre.Text = nombre;
                this.TXTapellido.Text = apellido;
                this.TXTdni.Text = dni.ToString();
                this.TXTmail.Text = mail;
                this.TXTtelefono.Text = telefono.ToString();
                this.TXTdomicilio.Text = domicilio;
                this.TXTcodigoPostal.Text = codigoPostal.ToString();
                this.TXTlocalidad.Text = localidad;
                this.DTEfechaNacimiento.Value = fecha;
                this.CMBestado.Text = estado;
                formularioPrecargado = true;
            
            };
        }

        public void recibirDatos(String nombre, String apellido, Int64 dni, String mail, String telefono, String domicilio, String codigoPostal, String localidad, DateTime fecha, String estado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            this.telefono = telefono;
            this.domicilio = domicilio;
            this.codigoPostal = codigoPostal;
            this.localidad = localidad;
            this.fecha = fecha;
            this.estado = estado;
            formularioPrecargado = true;

        }

        private void MensajeError() { 
        MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {

            if (this.ValidarCamposMandatorios())
            {
                if (formularioPrecargado) { this.crearCliente().modificate(); } else { this.crearCliente().guardate(); };
                this.Close();
            }
            else
            {
                this.MensajeError();
            };
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
            if (String.IsNullOrEmpty(this.TXTcodigoPostal.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTtelefono.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }

            return validado;

        }


        private void TXTdni_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private Cliente crearCliente() {
            return new Cliente(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTmail.Text,
                TXTtelefono.Text, TXTdomicilio.Text, TXTcodigoPostal.Text, TXTlocalidad.Text, Convert.ToDateTime(DTEfechaNacimiento.Text), CMBestado.Text);
        }

        private void DTEfechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BTNeliminar_Click(object sender, EventArgs e)
        {

        }

        private void TXTtelefono_TextChanged(object sender, EventArgs e)
        {
        }

        private void TXTtelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
  

    }
}
