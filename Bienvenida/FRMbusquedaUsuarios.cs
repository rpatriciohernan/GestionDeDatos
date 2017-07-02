using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Bienvenida
{
    public partial class FRMbusquedaUsuarios : Form
    {
        public FRMbusquedaUsuarios()
        {
            InitializeComponent();
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }


        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            if (TXTuserName.Text != "")
            {
                parametrosDeBusqueda.Add("username", TXTuserName.Text);
            }

            List<Usuario> usuarios = Usuario.buscar(parametrosDeBusqueda);
            construccionDeGridView(usuarios);
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
            //oculto columna de password
            dataGridView1.Columns["Password"].Visible = false;
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
                    FRMusuario formularioUsuario = new FRMusuario();
                    formularioUsuario.recibirDatosUsuario(Convert.ToString(row.Cells[2].Value), Convert.ToString(row.Cells[1].Value), Convert.ToInt64(row.Cells[0].Value), Convert.ToInt16(row.Cells[4].Value), Convert.ToString(row.Cells[3].Value));
                    formularioUsuario.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Usuario unUsuario = new Usuario(Convert.ToString(row.Cells[2].Value), Convert.ToInt16(row.Cells[4].Value), Convert.ToInt64(row.Cells[0].Value), "Inactivo" );
                    unUsuario.modificate();
                    this.busquedaDeValores();
                }
            }
        }

        private void FRMbusquedaUsuarios_Load(object sender, EventArgs e)
        {

            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

    }
}
