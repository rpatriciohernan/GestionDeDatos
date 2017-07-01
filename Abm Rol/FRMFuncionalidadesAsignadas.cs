using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Funcionalidad;

namespace UberFrba.Abm_Rol
{

   

    public partial class FRMFuncionalidadesAsignadas : Form
    {
        String nombreRol;
        Int16 idRol;
        Int16 idFuncionalidadSeleccionada;
        List<Funcionalidad> baseDeFuncionalidades;

        public FRMFuncionalidadesAsignadas(String rol)
        {
            InitializeComponent();
            TXTnombre.Text = rol;
        }

        public void recibirDatos(Int16 idRol, String nombreRol) {
            this.idRol = idRol;
            this.nombreRol = nombreRol;
        }

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusquedaAsignaciones = new Dictionary<string, string>();

            if (TXTnombre.Text != "")
            {
                parametrosDeBusquedaAsignaciones.Add("id_rol", Convert.ToString(idRol));
            }

            List<FuncionalidadAsignada> funcionalidadesAsignadas = FuncionalidadAsignada.buscar(parametrosDeBusquedaAsignaciones);
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            

            funcionalidadesAsignadas.ForEach(funcionalidadAsignada => BuscarNombreFuncionalidad(funcionalidadAsignada, funcionalidades));


            construccionDeGridView(funcionalidades);
        }

        private void BuscarNombreFuncionalidad(FuncionalidadAsignada funcionalidadAisgnada, List<Funcionalidad> funcionalidades) { 
                     Dictionary<String, String> parametrosDeBusquedaNombre = new Dictionary<string, string>();
                     parametrosDeBusquedaNombre.Add("id_funcionalidad", Convert.ToString(funcionalidadAisgnada.IdFuncionalidad));
                     funcionalidades.Add(Funcionalidad.buscar(parametrosDeBusquedaNombre).First());
        }

        private void completarBaseDeFuncionalidades() {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            baseDeFuncionalidades = Funcionalidad.buscar(parametrosDeBusqueda);
        }

        private void completarComboBox() { 
            baseDeFuncionalidades.ForEach( funcionalidad =>
                    CMBfuncionalidad.Items.Add(funcionalidad.Nombre)
                );
        }

        private void FRMFuncionalidadesAsignadas_Load(object sender, EventArgs e)
        {
            TXTnombre.Text = nombreRol;
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
            // CARGA DE COMBO BOX Y LISTA FUNCIONALIDADES
            completarBaseDeFuncionalidades();
            completarComboBox();
            //carga inicial de func asignadas
            busquedaDeValores();
        }

        private void construccionDeGridView(object dataSource)
        {
            //asociacion de datagrid con base de datos
            BindingSource bs = new BindingSource(dataSource, "");
            dataGridView1.DataSource = bs;
            dataGridView1.RowHeadersVisible = false;
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
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    FuncionalidadAsignada funcionalidadAEliminar = new FuncionalidadAsignada(idRol, Convert.ToInt16(row.Cells[0].Value));
                    funcionalidadAEliminar.eliminate();
                    busquedaDeValores();
                }
            }
        }

        private void BTNterminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void BTNnuevaFuncionalidad_Click(object sender, EventArgs e)
        {
            FRMFuncionalidad frmfuncionalidad = new FRMFuncionalidad();
            frmfuncionalidad.Show();

        }


        private Int16 obtenerIdFuncionalidadSeleccionada() {
            return baseDeFuncionalidades.Find(funcionalidad => funcionalidad.Nombre == CMBfuncionalidad.Text).IdFuncionalidad;
        }



        private void BTNagregar_Click(object sender, EventArgs e)
        {
            idFuncionalidadSeleccionada = obtenerIdFuncionalidadSeleccionada();
            FuncionalidadAsignada funcionalidadAsignada = new FuncionalidadAsignada(idRol, idFuncionalidadSeleccionada);
            funcionalidadAsignada.guardate();
            this.busquedaDeValores();
        }

        private void BTNeliminarFuncionalidad_Click(object sender, EventArgs e)
        {
            FRMFuncionalidad frmfuncionalidad = new FRMFuncionalidad();
            frmfuncionalidad.obtenerValores(CMBfuncionalidad.Text);
            frmfuncionalidad.Show();

        }

        private void CMBfuncionalidad_Click(object sender, EventArgs e)
        {
            CMBfuncionalidad.Items.Clear();
            completarBaseDeFuncionalidades();
            completarComboBox();
        }
    }
}
