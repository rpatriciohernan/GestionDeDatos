using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class FRMFuncionalidadesAsignadas : Form
    {
        public FRMFuncionalidadesAsignadas(String rol)
        {
            InitializeComponent();
            TXTnombre.Text = rol;
        }

        private void FRMFuncionalidadesAsignadas_Load(object sender, EventArgs e)
        {

        }

        private void BTNterminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNagregar_Click(object sender, EventArgs e)
        {

        }
    }
}
