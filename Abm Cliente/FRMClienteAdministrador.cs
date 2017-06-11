using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class FRMClienteAdministrador : Form
    {
        private List<Label> labelsConErrores = new List<Label>();
        public FRMClienteAdministrador()
        {
            InitializeComponent();
        }

        private void FRMCliente_Load(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private Cliente CrearCliente()
        {
            return new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt64(txtDni.Text), txtMail.Text, txtTelefono.Text,
            txtCalle.Text, Convert.ToInt16(txtNumero.Text), txtPiso.Text, txtDepto.Text, txtLocalidad.Text, txtCodigoPostal.Text, Convert.ToDateTime(dteFechaNacimiento.Text));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LimpiarErrores();

            Cliente cliente = CrearCliente();
            List<ErrorDeCampo> errores = cliente.validarCampos();

            if (errores.Count > 0)
            {
                mostrarErrores(errores);
            }
            else
            {
                cliente.guardate();
            }
        }




        //-----logica de visualizacion de errores, hubiese estado copado generalizarla pero es un bardo :(-------
        private void LimpiarErrores()
        {
            labelsConErrores.ForEach(lbl => lbl.Text = "");
        }

        private void mostrarErrores(List<ErrorDeCampo> errores)
        {
            foreach (ErrorDeCampo error in errores)
            {
                Label lbl = this.Controls.Find("lbl" + error.NombreCampo + "Error", true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    lbl.Text = error.Sugerencia;
                    labelsConErrores.Add(lbl);
                }
            }
        }

        private void lblNombreError_Click(object sender, EventArgs e)
        {

        }
        //---------------------------------------------------------

    }
}
