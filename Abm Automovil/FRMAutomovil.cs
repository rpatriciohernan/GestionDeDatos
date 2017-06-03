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
    public partial class FRMAutomovil : Form
    {
        public FRMAutomovil()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            FRMMarcaVehiculo formularioMarcas = new FRMMarcaVehiculo();

            // Show the settings form
            formularioMarcas.Show();
        }
    }
}
