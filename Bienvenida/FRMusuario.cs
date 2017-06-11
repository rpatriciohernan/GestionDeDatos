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
    public partial class FRMusuario : Form
    {
        public FRMusuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMrolesAsignados formularioRoles = new FRMrolesAsignados();

            // Show form
            formularioRoles.Show();
        }
    }
}
