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
        public FRMChofer(String dni)
        {
            InitializeComponent();
            TXTdni.Text = dni;
        }

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
            if (this.CMBestado.Text == "") { this.CMBestado.Text = "Activo"; };

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
                this.crearChofer().guardate();
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
