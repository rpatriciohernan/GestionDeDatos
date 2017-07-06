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
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;

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
            busquedaDeValores();
        }

        private void busquedaDeValores()
        {

            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            if (txtNombre.Text != "")
            {
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

            construccionDeGridView(clientes);
        }


        private void construccionDeGridView(object dataSource)
        {
            //asociacion de datagrid con base de datos
            BindingSource bs = new BindingSource(dataSource, "");
            dataGridView1.DataSource = bs;
            dataGridView1.RowHeadersVisible = false;
            //creacion de boton para editar
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Editar";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["Editar"] == null)
            {
                dataGridView1.Columns.Add(editButtonColumn);
            }
            else
            {
                dataGridView1.Columns.Remove("Editar");
                dataGridView1.Columns.Add(editButtonColumn);

            }
            //creacion de boton para buscar
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Eliminar";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["Eliminar"] == null)
            {
                dataGridView1.Columns.Add(deleteButtonColumn);
            }
            else
            {
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Add(deleteButtonColumn);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    FRMCliente formularioCliente = new FRMCliente();
                    formularioCliente.recibirDatos(Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToInt64(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[7].Value), Convert.ToDateTime(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                    formularioCliente.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Cliente unCliente = new Cliente(Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToInt64(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[7].Value), Convert.ToDateTime(row.Cells[8].Value), Convert.ToString(row.Cells[9].Value));
                    unCliente.eliminate();
                    this.busquedaDeValores();
                }
            }
        }



        private void CHKsoloActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTNnuevoCliente_Click(object sender, EventArgs e)
        {
            FRMCliente formularioNuevoCliente = new FRMCliente();
            formularioNuevoCliente.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
