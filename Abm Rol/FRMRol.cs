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
    public partial class FRMRol : Form
    {
        Int16 idRol;
        String nombre;
        String estado;

        public FRMRol()
        {
            InitializeComponent();
        }


        public void recibirDatosRol(Int16 id, String nombre, String estado) {
            this.nombre = nombre;
            this.estado = estado;
            this.idRol = id;
            
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNFuncionalidades_Click(object sender, EventArgs e)
        {
            FRMFuncionalidadesAsignadas formularioFuncionalidades = new FRMFuncionalidadesAsignadas(TXTnombre.Text);
            formularioFuncionalidades.recibirDatos(idRol, nombre);
            formularioFuncionalidades.Show();
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
       }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTnombre.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }

            return validado;

        }

        private Rol crearRol()
        {
            return new Rol(idRol,TXTnombre.Text, CMBestado.Text);
        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {

            if (this.ValidarCamposMandatorios())
            {
                this.crearRol().modificate();
                this.Close();
            }
            else
            {
                this.MensajeError();
            };
        }

        private void BTNeliminar_Click(object sender, EventArgs e)
        {
            this.crearRol().eliminate();
            this.Close();
        }

        private void FRMRol_Load(object sender, EventArgs e)
        {
           TXTnombre.Text = this.nombre;
           CMBestado.Text = this.estado;
        }
    }
}
