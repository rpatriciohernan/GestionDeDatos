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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

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
            if (CHKsoloActivos.Checked)
            {
                parametrosDeBusqueda.Add("cliente_estado", "Activo");
            }
            List<Cliente> clientes = Cliente.buscar(parametrosDeBusqueda);

            BindingSource bs = new BindingSource(clientes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false); hay que hacerlo cada vez que se actualiza la lista
        }

        private void CHKsoloActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
