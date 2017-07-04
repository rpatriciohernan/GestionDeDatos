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
    public partial class FRMmarca : Form
    {
        public FRMmarca()
        {
            InitializeComponent();
        }
        String nombre;
        Int16 idMarca;
        Boolean formularioPrecargado = false;
        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TXTnombre.Text)) {
                MensajeError();
            }
            else
            {
                if (formularioPrecargado)
                {
                    Marca nuevaMarca = new Marca(idMarca, TXTnombre.Text);
                    nuevaMarca.modificate();
                }
                else
                {
                    Marca nuevaMarca = new Marca(TXTnombre.Text);
                    nuevaMarca.guardate();
                };
                    
            }

        }

        public void recibirDatos(Int16 idMarca, String nombre) {
            this.nombre = nombre;
            this.idMarca = idMarca;
            formularioPrecargado = true;
        }

        private void FRMmarca_Load(object sender, EventArgs e)
        {
            if (formularioPrecargado) {
                this.TXTnombre.Text = nombre;
            }
        }
    }
}
