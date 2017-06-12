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
    public partial class FRMBuscarCliente : Form
    {
        private List<Label> labelsConErrores = new List<Label>();
        public FRMBuscarCliente()
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
           /* return new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt64(txtDni.Text), txtMail.Text, txtTelefono.Text,
            txtCalle.Text, Convert.ToInt16(txtNumero.Text), txtPiso.Text, txtDepto.Text, txtLocalidad.Text, txtCodigoPostal.Text, Convert.ToDateTime(dteFechaNacimiento.Text));
        
            */
            return null;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            if (txtNombre.Text != "") {
                parametrosDeBusqueda.Add("cliente_nombre", txtNombre.Text);
            }
            if (txtApellido.Text != "")
            {
                parametrosDeBusqueda.Add("cliente_apellido", txtApellido.Text);
            }
            if (txtDni.Text != "")
            {
                parametrosDeBusqueda.Add("cliente_dni", txtDni.Text);
            }

            List<Cliente> clientes = Cliente.buscar(parametrosDeBusqueda);

            BindingSource bs = new BindingSource(clientes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false); hay que hacerlo cada vez que se actualiza la lista
        }

        private void CHKsoloActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
