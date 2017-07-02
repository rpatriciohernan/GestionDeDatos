using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class FRMBuscarRol : Form
    {
        public FRMBuscarRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNFuncionalidades_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMFuncionalidadesAsignadas formularioFuncionalidades = new FRMFuncionalidadesAsignadas(TXTnombre.Text);

            // Show form
            formularioFuncionalidades.Show();
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }


        private void busquedaDeValores() {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            if (TXTnombre.Text != "")
            {
                parametrosDeBusqueda.Add("rol_nombre", TXTnombre.Text);
            }
            if (CMBestado.Text != "")
            {
                parametrosDeBusqueda.Add("rol_estado", CMBestado.Text);
            }

            List<Rol> roles = Rol.buscar(parametrosDeBusqueda);
            construccionDeGridView(roles);
        }

        private void construccionDeGridView(object dataSource) { 
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
            if (dataGridView1.Columns["Editar"] == null){
                dataGridView1.Columns.Add(editButtonColumn);
            } else {
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
            } else {
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Add(deleteButtonColumn);
            }
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex >= 0){
                if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    FRMRol formularioRol = new FRMRol();
                    formularioRol.recibirDatosRol(Convert.ToInt16(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value));
                    formularioRol.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Rol unRol = new Rol(Convert.ToInt16(row.Cells[0].Value), Convert.ToString(row.Cells[1].Value), "Inactivo");
                    unRol.modificate();
                    this.busquedaDeValores();
                }
            }   
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTnombre.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }

            return validado;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTNnuevo_Click(object sender, EventArgs e)
        {
            //Rol nuevoRol = new Rol(TXTnombre.Text, CMBestado.Text);
            //nuevoRol.guardate();
            //busquedaDeValores();
            FRMRol formularioNuevoRol = new FRMRol();
            formularioNuevoRol.altaDeRolActivada();
            formularioNuevoRol.Show();
        }

        private void FRMBuscarRol_Load(object sender, EventArgs e)
        {
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

    }
}
