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
    public partial class FRMMarcaVehiculo : Form
    {
        public FRMMarcaVehiculo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FRMMarcaVehiculo_Load(object sender, EventArgs e)
        {
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            if (TXTnombre.Text != "")
            {
                parametrosDeBusqueda.Add("marca_nombre", TXTnombre.Text);
            }

            List<Marca> marcas = Marca.buscar(parametrosDeBusqueda);
            construccionDeGridView(marcas);
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
                    FRMmarca formularioMarca = new FRMmarca();
                    formularioMarca.recibirDatos(Convert.ToInt16(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value));
                    formularioMarca.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Marca unaMarca = new Marca(Convert.ToInt16(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value));
                    unaMarca.eliminate();
                    this.busquedaDeValores();
                }
            }
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            FRMmarca formularioNuevaMarca = new FRMmarca();
            formularioNuevaMarca.Show();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();

        }
    }
}


