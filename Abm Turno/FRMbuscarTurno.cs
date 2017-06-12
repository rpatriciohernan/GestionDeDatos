using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class FRMbuscarTurno : Form
    {
        public FRMbuscarTurno()
        {
            InitializeComponent();
        }

        private void BTNnuevoTurno_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMTurno formularioTurno = new FRMTurno();

            // Show form
            formularioTurno.Show();

        }
    }
}
