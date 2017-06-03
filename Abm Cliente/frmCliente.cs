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
    public partial class FRMCliente : Form
    {
        private List<Label> labelsConErrores = new List<Label>();
        public FRMCliente()
        {
            InitializeComponent();
        }

       // private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void label2_Click(object sender, EventArgs e)
        {

        } 

        private Cliente CrearCliente() {
            return new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt64(txtDNI.Text), txtMail.Text, txtTelefono.Text,
            txtDireccion.Text, txtCodigoPostal.Text, Convert.ToDateTime(txtFechaNacimiento.Text));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            if (txtNombre.Text != "") {
                parametrosDeBusqueda.Add("nombre", txtNombre.Text);
            }
            if (txtApellido.Text != "")
            {
                parametrosDeBusqueda.Add("apellido", txtApellido.Text);
            }
            if (txtDNI.Text != "")
            {
                parametrosDeBusqueda.Add("dni", txtDNI.Text);
            }

            List<Cliente> clientes = Cliente.buscar(parametrosDeBusqueda);

            

            BindingSource bs = new BindingSource(clientes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false); hay que hacerlo cada vez que se actualiza la lista


        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Conexion.startConexion();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LimpiarErrores();

            Cliente cliente = CrearCliente();
            List<ErrorDeCampo> errores = cliente.validarCampos();

            if (errores.Count > 0) {
                mostrarErrores(errores);
            } else {
                cliente.guardate();
            }
        }



        //-----logica de visualizacion de errores, hubiese estado copado generalizarla pero es un bardo :(-------
        private void LimpiarErrores() {
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
        //---------------------------------------------------------



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
