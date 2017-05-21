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
    public partial class frmCliente : Form
    {
        private List<Label> labelsConErrores = new List<Label>();
        public frmCliente()
        {
            InitializeComponent();
        }

       // private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void label2_Click(object sender, EventArgs e)
        {

        } 

        private Cliente CrearCliente() {
            return new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt64(txtDNI.Text), txtMail.Text, txtTelefono.Text,
            txtDireccion.Text, txtCodigoPostal.Text, Convert.ToDateTime(txtFechaNacimiento.Text));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //generamos el gliente
            var cliente = CrearCliente();

            Boolean tieneNombre = cliente.validarNombre();

            Console.WriteLine(tieneNombre);
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Conexion.startConexion();

            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona("nombre1","apellido1"));
            personas.Add(new Persona("nombre2","apellido2"));
            personas.Add(new Persona("nombre3","apellido3"));

            BindingSource bs = new BindingSource(personas, "");

            dataGridView1.DataSource = bs;
           

            personas.Add(new Persona("nombre4", "apellido4"));
            bs.ResetBindings(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LimpiarErrores();

            Cliente cliente = CrearCliente();
            List<ErrorDeCampo> errores = cliente.validarCampos();

            if (errores.Count != 0) {
                mostrarErrores(errores);
            } else {
                cliente.guardate();
            }
        }



        //-----esta logica tiene que ir en el form generico-------
        private void LimpiarErrores() {
            labelsConErrores.ForEach(lbl => lbl.Text = "");
        }

        private void mostrarErrores(List<ErrorDeCampo> errores)
        {
            foreach (ErrorDeCampo error in errores)
            {
                Label lbl = this.Controls.Find("lbl" + error.NombreCampo + "Error", true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    lbl.Text = error.Sugerencia;
                    labelsConErrores.Add(lbl);
                }
            }
        }
        //---------------------------------------------------------



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
public Cliente(String nombre, String apellido, Int64 dni, String mail, String telefono,
            String direccion, String codigoPostal, DateTime fechaNacimiento)
 
 */