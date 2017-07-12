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
using UberFrba.Abm_Turno;

namespace UberFrba.Abm_Automovil
{
    public partial class FRMbuscarVehiculo : Form
    {
        public FRMbuscarVehiculo()
        {
            InitializeComponent();
        }

        private List<Marca> marcas;
        private List<Turno> turnos;
        private List<Chofer> choferes;

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            if (TXTpatente.Text != "")
            {
                parametrosDeBusqueda.Add("auto_patente", TXTpatente.Text);
            }
            if (CMBmarca.Text != "")
            {
                Int16 idMarca = marcas.Find(marca => marca.Nombre == CMBmarca.Text).IdMarca;
                parametrosDeBusqueda.Add("id_marca", idMarca.ToString());
            }
            if (TXTmodelo.Text != "")
            {
                parametrosDeBusqueda.Add("auto_modelo", TXTmodelo.Text);
            }
            if (CMBChofer.Text != "")
            {
                Int64 dniChofer = choferes.Find(chofer => chofer.Nombre == CMBChofer.Text).Dni;
                parametrosDeBusqueda.Add("id_chofer", dniChofer.ToString());
            }
            if (CHKsoloActivos.Checked)
            {
                parametrosDeBusqueda.Add("auto_estado", "Activo");
            }
            List<Automovil> automoviles = Automovil.buscar(parametrosDeBusqueda);

            construccionDeGridView(automoviles);
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
                    FRMAutomovil formularioAuto = new FRMAutomovil();
                    formularioAuto.obtenerDatos(Convert.ToString(row.Cells[0].Value), Convert.ToInt16(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToInt16(row.Cells[3].Value), Convert.ToInt64(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value));
                    formularioAuto.Show();
                }
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    Automovil unAutomovil = new Automovil(Convert.ToString(row.Cells[0].Value), Convert.ToInt16(row.Cells[1].Value), Convert.ToString(row.Cells[2].Value), Convert.ToInt16(row.Cells[3].Value), Convert.ToInt64(row.Cells[4].Value), "Inactivo");
                    unAutomovil.modificate();
                    this.busquedaDeValores();
                }
            }
        }

        private void FRMbuscarVehiculo_Load(object sender, EventArgs e)
        {
            Dictionary<String, String> searchAllMarcas = new Dictionary<string, string>();

            marcas = Marca.buscar(searchAllMarcas);
            // turnos = Turno.buscar(searchAll);

            Dictionary<String, String> searchAllChoferes = new Dictionary<string, string>();
            searchAllChoferes.Add("chofer_estado", "Activo");
            choferes = Chofer.buscar(searchAllChoferes);

            //---Atributos que mostramos en los combos---
            marcas.ForEach(marca => CMBmarca.Items.Add(marca.Nombre));

            // turnos.ForEach(turno => CMBturno.Items.Add(turno.Descripcion));

            choferes.ForEach(chofer => CMBChofer.Items.Add(chofer.Nombre));


            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        private void BTNnuevoVehiculo_Click(object sender, EventArgs e)
        {
            FRMAutomovil formularioAutomovil = new FRMAutomovil();
            formularioAutomovil.Show();
        }
    }
}
