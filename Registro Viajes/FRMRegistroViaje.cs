using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;

namespace UberFrba.Registro_Viajes
{
    public partial class FRMregistroViaje : Form
    {
        private List<Cliente> clientes;
        private List<Chofer> choferes;
        private List<Turno> turnos;

        public FRMregistroViaje()
        {
            InitializeComponent();
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.cmbChofer.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.txtAutomovil.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.cmbTurno.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.dteFechaInicio.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.dtpFechaFin.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.cmbCliente.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.txtKilometros.Text)) { validado = false; }

            return validado;

        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                this.crearViaje().guardate();
            }
            else
            {
                this.MensajeError();
            };
        }

        private Viaje crearViaje() {

            Int64 idChofer = getIdChoferSeleccionado();
            Int64 idCliente = getIdClienteSeleccionado();
            Int64 idTurno = getIdTurno();
            Double cantidadKilometros = Convert.ToDouble(txtKilometros.Text);

            return new Viaje(idChofer, txtAutomovil.Text, idTurno, cantidadKilometros, Convert.ToDateTime(dteFechaInicio.Text), Convert.ToDateTime(dtpFechaFin.Text), idCliente, -1); //como no tenemos idFactura, le seteamos -1
        }

        private void FRMregistroViaje_Load(object sender, EventArgs e)
        {
            dteFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm:ss";

            Dictionary<String, String> searchAll = new Dictionary<string, string>();

            clientes = Cliente.buscar(searchAll);
            choferes = Chofer.buscar(searchAll);
            turnos = Turno.buscar(searchAll);

            //---Atributos que mostramos en los combos---
            clientes.ForEach(cliente => cmbCliente.Items.Add(cliente.Nombre + ", " + cliente.Apellido));
            choferes.ForEach(chofer => cmbChofer.Items.Add(chofer.Nombre + ", " + chofer.Apellido));
            turnos.ForEach(turno => cmbTurno.Items.Add(turno.Descripcion));
        }

        private Int64 getIdChoferSeleccionado()
        {//si hay 2 choferes con mismo nombre y apellido no funciona -> habria que hacerlo por posicion del combo, mostrando en el combo el nombre, apellido y dni ;)!!
            return choferes.Find(chofer => chofer.Nombre + ", " + chofer.Apellido == cmbChofer.Text).Dni;
        }

        private Int64 getIdTurno()
        {
            return turnos.Find(turno => turno.Descripcion == cmbTurno.Text).IdTurno;
        }

        private Int64 getIdClienteSeleccionado()
        {//si hay 2 choferes con mismo nombre y apellido no funciona -> habria que hacerlo por posicion del combo, mostrando en el combo el nombre, apellido y dni ;)!!
            return clientes.Find(cliente => cliente.Nombre + ", " + cliente.Apellido == cmbCliente.Text).Dni;
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
