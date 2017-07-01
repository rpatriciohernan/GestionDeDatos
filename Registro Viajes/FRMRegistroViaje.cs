using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class FRMregistroViaje : Form
    {
        public FRMregistroViaje()
        {
            InitializeComponent();
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            this.crearViaje().guardate();
        }

        private Viaje crearViaje() {

            Int16 idChofer = Convert.ToInt16(cmbChofer.Text);
            Double cantidadKilometros = Convert.ToDouble(txtKilometros.Text);
            Int16 idCliente = Convert.ToInt16(cmbCliente.Text);
            
            return new Viaje(Convert.ToInt16(cmbChofer.Text), txtAutomovil.Text, Convert.ToInt16(cmbTurno.Text), Convert.ToDouble(txtKilometros.Text), Convert.ToDateTime(dteFechaInicio.Text), Convert.ToDateTime(dtpFechaFin.Text), Convert.ToInt16(cmbCliente.Text),-1); //como no tenemos idFactura, le seteamos -1
        }
    }
}
