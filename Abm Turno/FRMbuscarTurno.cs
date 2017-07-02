using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class FRMbuscarTurno : Form
    {
        public FRMbuscarTurno()
        {
            InitializeComponent();
        }

        private void BTNnuevoTurno_Click(object sender, EventArgs e)
        {

            FRMTurno formularioTurno = new FRMTurno();
            formularioTurno.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    FRMTurno formularioTurno = new FRMTurno();
                    formularioTurno.obtenerValores(Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToDateTime(row.Cells[3].Value), Convert.ToDateTime(row.Cells[4].Value), Convert.ToInt16(row.Cells[5].Value), Convert.ToInt16(row.Cells[6].Value));
                    formularioTurno.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Turno unTurno = new Turno(Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), Convert.ToInt16(row.Cells[4].Value), Convert.ToInt16(row.Cells[5].Value));
                    unTurno.eliminate();
                    this.busquedaDeValores();
                }
            }
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

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            if (TXTnombre.Text != "")
            {
                parametrosDeBusqueda.Add("turno_descripcion", TXTnombre.Text);
            }

            List<Turno> turnos = Turno.buscar(parametrosDeBusqueda);
            construccionDeGridView(turnos);
        }

        private void FRMbuscarTurno_Load(object sender, EventArgs e)
        {
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }
    }
}
