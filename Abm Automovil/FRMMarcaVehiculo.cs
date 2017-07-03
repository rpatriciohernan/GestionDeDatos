using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class FRMMarcaVehiculo : Form
    {
        public FRMMarcaVehiculo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FRMMarcaVehiculo_Load(object sender, EventArgs e)
        {

        }

        private Marca crearMarca() {
            return new Marca(TXTnombre.Text);
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            Marca marca = crearMarca();
                marca.guardate();
            }
        }
}

