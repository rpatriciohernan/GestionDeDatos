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
        String nombreRol;
        Int16 idRol;
        public FRMFuncionalidadesAsignadas(String rol)
        {
            InitializeComponent();
            TXTnombre.Text = rol;
        }

        public void recibirDatos(Int16 idRol, String nombreRol) {
            this.idRol = idRol;
            this.nombreRol = nombreRol;
        }

        private void FRMFuncionalidadesAsignadas_Load(object sender, EventArgs e)
        {
            TXTnombre.Text = nombreRol;
        }

        
        
        private void BTNterminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
