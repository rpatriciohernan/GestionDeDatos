﻿using System;
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
    public partial class FRMRol : Form
    {
        public FRMRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNFuncionalidades_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMFuncionalidadesAsignadas formularioFuncionalidades = new FRMFuncionalidadesAsignadas(TXTnombre.Text);

            // Show form
            formularioFuncionalidades.Show();
        }
    }
}