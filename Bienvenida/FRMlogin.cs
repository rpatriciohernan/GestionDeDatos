using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Bienvenida
{
    public partial class FRMlogin : Form
    {
        public FRMlogin()
        {
            InitializeComponent();
        }

        private void BTNingresar_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMBienvenida formularioBienvenida = new FRMBienvenida();

            // Show form
            formularioBienvenida.Show();

            //Hide actual form (not closing cause it turns the app off)
            this.Hide();
        }

        private void BTNnuevoUsuario_Click_1(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMnuevoUsuario formularioNuevoUsuario = new FRMnuevoUsuario();

            // Show form
            formularioNuevoUsuario.Show();
        }
    }
}
