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
    public partial class FRMTurno : Form
    {
        public FRMTurno()
        {
            InitializeComponent();
            CMBestado.Items.Add("Habilitado");
            CMBestado.Items.Add("Inhabilitado");
        }

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
