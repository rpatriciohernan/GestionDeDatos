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
    public partial class frmCliente : Form
    {
        private List<Label> labelsConErrores = new List<Label>();
        public frmCliente()
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
            /*var cliente = CrearCliente();

            Boolean tieneNombre = cliente.validarNombre();

            Console.WriteLine(tieneNombre);*/
           
           /* Int64 dni = Convert.ToInt64(txtDNI.Text);
            Cliente cliente = Cliente.buscar(dni);*/

            List<Cliente> clientes = Cliente.buscarTodos();

            //Console.WriteLine("el cliente buscado es: " + cliente.Nombre);

            BindingSource bs = new BindingSource(clientes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false);


        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Conexion.startConexion();

         /*   List<Persona> personas = new List<Persona>();
            personas.Add(new Persona("nombre1","apellido1"));
            personas.Add(new Persona("nombre2","apellido2"));
            personas.Add(new Persona("nombre3","apellido3"));

            BindingSource bs = new BindingSource(personas, "");

            dataGridView1.DataSource = bs;
           

            personas.Add(new Persona("nombre4", "apellido4"));
            bs.ResetBindings(false); cada vez que cambia la lista que infla la grilla, hay que hacer esto para que la grilla muestre los cambios
            */
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
