using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;

namespace UberFrba.Abm_Chofer_Administrador
{
    public partial class FRMBuscarChofer : Form
    {
        public FRMBuscarChofer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FRMChofer_Load(object sender, EventArgs e)
        {

            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            if (TXTnombre.Text != "")
            {
                parametrosDeBusqueda.Add("chofer_nombre", TXTnombre.Text);
            }
            if (TXTapellido.Text != "")
            {
                parametrosDeBusqueda.Add("chofere_apellido", TXTapellido.Text);
            }
            if (TXTdni.Text != "")
            {
                parametrosDeBusqueda.Add("chofer_dni", TXTdni.Text);
            }
            if (CHKsoloActivos.Checked)
            {
                parametrosDeBusqueda.Add("chofer_estado", "Activo");
            }

            List<Chofer> choferes = Chofer.buscar(parametrosDeBusqueda);
            construccionDeGridView(choferes);
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
                    FRMChofer formularioChofer = new FRMChofer();
                    formularioChofer.recibirDatos(Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToInt64(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToDateTime(row.Cells[7].Value), Convert.ToString(row.Cells[8].Value));
                    formularioChofer.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Chofer unChofer = new Chofer(Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToInt64(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[6].Value), Convert.ToDateTime(row.Cells[7].Value), Convert.ToString(row.Cells[8].Value));
                    unChofer.eliminate();
                    this.busquedaDeValores();
                }
            }
        }


        private void BTNnuevoChofer_Click(object sender, EventArgs e)
        {
            FRMChofer formularioNuevoChofer = new FRMChofer();
            formularioNuevoChofer.Show();
        }
    }
}
