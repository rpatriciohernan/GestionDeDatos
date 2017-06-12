﻿using System;
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
        public FRMCliente( String dni)
        {
            InitializeComponent();
            TXTdni.Text = dni;
        }

        private void FRMCliente_Load(object sender, EventArgs e)
        {
            this.CMBestado.Items.Add("Activo");
            this.CMBestado.Items.Add("Inactivo");
            if (this.CMBestado.Text == "") { this.CMBestado.Text = "Activo"; };
        }

        private void MensajeError() { 
        MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {

            if (this.ValidarCamposMandatorios())
            {
                this.crearCliente().guardate();
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

        private Cliente crearCliente() {
            return new Cliente(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTmail.Text,
                TXTtelefono.Text, TXTdomicilio.Text,Convert.ToInt16(TXTcodigoPostal.Text), TXTlocalidad.Text, Convert.ToDateTime(DTEfechaNacimiento.Text), CMBestado.Text);
        }

        private void DTEfechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
