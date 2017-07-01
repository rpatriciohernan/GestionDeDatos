using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Funcionalidad
{
    public partial class FRMFuncionalidad : Form
    {
        String nombreFuncionalidad = "";
        
        public FRMFuncionalidad()
        {
            InitializeComponent();
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if  (String.IsNullOrEmpty(this.TXTnombre.Text)){
                MensajeError();
            } else {
                Funcionalidad nuevaFuncionalidad = new Funcionalidad(TXTnombre.Text);
                nuevaFuncionalidad.guardate();
                this.Close();
            }
        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void obtenerValores(String nombreFuncionalidad) {
            this.nombreFuncionalidad = nombreFuncionalidad;
        }


        private void BTNeliminar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.TXTnombre.Text))
            {
                MensajeError();
            }
            else
            {
                Funcionalidad nuevaFuncionalidad = new Funcionalidad(TXTnombre.Text);
                nuevaFuncionalidad.eliminate();
                this.Close();
            }
        }

        private void FRMFuncionalidad_Load(object sender, EventArgs e)
        {
            TXTnombre.Text = this.nombreFuncionalidad;
        }


    }
        
}
