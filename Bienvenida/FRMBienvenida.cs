﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Chofer_Administrador;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Facturacion;
using UberFrba.Listado_Estadistico;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;

namespace UberFrba.Bienvenida
{
    public partial class FRMBienvenida : Form
    {
        public FRMBienvenida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMBuscarCliente formularioCliente = new FRMBuscarCliente();

            // Show form
            formularioCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMBuscarChofer formularioChofer = new FRMBuscarChofer();

            // Show form
            formularioChofer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMAutomovil formularioVehiculo = new FRMAutomovil();

            // Show form
            formularioVehiculo.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMRol formularioRoles = new FRMRol();

            // Show form
            formularioRoles.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMbuscarTurno formularioTurno = new FRMbuscarTurno();

            // Show form
            formularioTurno.Show();
        }

        private void BTNnuevoUsuario_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMnuevoUsuario formularioNuevoUsuario = new FRMnuevoUsuario();

            // Show form
            formularioNuevoUsuario.Show();
        }

        private void FRMBienvenida_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMregistroViaje formularioRegistroViaje = new FRMregistroViaje();

            // Show form
            formularioRegistroViaje.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMrendicion formularioRendicion = new FRMrendicion();

            // Show form
            formularioRendicion.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMfacturacion formularioFacturacion = new FRMfacturacion();

            // Show form
            formularioFacturacion.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMestadistica formularioEstadistica = new FRMestadistica();

            // Show form
            formularioEstadistica.Show();
        }

        private void BTNaltaUsuario_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMnuevoUsuario formularioNuevoUsuario = new FRMnuevoUsuario();

            // Show form
            formularioNuevoUsuario.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMbusquedaUsuarios formularioBuscarUsuario = new FRMbusquedaUsuarios();

            // Show form
            formularioBuscarUsuario.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMviajesRegistrados formularioViajesRegistrados = new FRMviajesRegistrados();

            // Show form
            formularioViajesRegistrados.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMmisFacturaciones formularioFacturaciones = new FRMmisFacturaciones();

            // Show form
            formularioFacturaciones.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMviajesRendidos formularioViajesRendidos = new FRMviajesRendidos();

            // Show form
            formularioViajesRendidos.Show();
        }

        private void BTNbuscarVehiculos_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMbuscarVehiculo formularioBuscarVehiculo = new FRMbuscarVehiculo();

            // Show form
            formularioBuscarVehiculo.Show();
        }
    }
}