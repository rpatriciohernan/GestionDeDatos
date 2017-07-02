using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Rol;

namespace UberFrba.Bienvenida
{
    public partial class FRMrolesAsignados : Form
    {
        Int16 idRolSeleccionado;
        List<Rol> baseDeRoles;
        String username;

        public FRMrolesAsignados()
        {
            InitializeComponent();
        }

        private void BTNterminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void recibirDatosUsuario(String username)
        {
            this.username = username;
        }

        private void busquedaDeValores()
        {
            Dictionary<String, String> parametrosDeBusquedaRoles = new Dictionary<string, string>();

            if (TXTusuario.Text != "")
            {
                parametrosDeBusquedaRoles.Add("username", Convert.ToString(username));
            }

            List<RolAsignado> rolesAsignados = RolAsignado.buscar(parametrosDeBusquedaRoles);
            List<Rol> roles = new List<Rol>();



            rolesAsignados.ForEach(rolAsignado => BuscarNombreRol(rolAsignado, roles));


            construccionDeGridView(roles);
        }

        private void BuscarNombreRol(RolAsignado rolAsignado, List<Rol> roles)
        {
            Dictionary<String, String> parametrosDeBusquedaNombre = new Dictionary<string, string>();
            parametrosDeBusquedaNombre.Add("id_rol", Convert.ToString(rolAsignado.IdRol));
            roles.Add(Rol.buscar(parametrosDeBusquedaNombre).First());
        }

        private void completarBaseDeRoles()
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("rol_estado", "Activo");
            baseDeRoles = Rol.buscar(parametrosDeBusqueda);
        }

        private void completarComboBox()
        {
            baseDeRoles.ForEach(rol =>
                    CMBrol.Items.Add(rol.Nombre)
                );
        }


        private void FRMrolesAsignados_Load(object sender, EventArgs e)
        {
            TXTusuario.Text = username;
            //asociacion de datagrid con el evento de clic en boton
            dataGridView1.CellClick += dataGridView1_CellClick;
            // CARGA DE COMBO BOX Y LISTA FUNCIONALIDADES
            completarBaseDeRoles();
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
                    RolAsignado rolAEliminar = new RolAsignado(username, Convert.ToInt16(row.Cells[0].Value));
                    rolAEliminar.eliminate();
                    busquedaDeValores();
                }
            }
        }


        private Int16 obtenerIdRolSeleccionado()
        {
            return baseDeRoles.Find(rol => rol.Nombre == CMBrol.Text).Id;
        }


        private void BTNagregar_Click(object sender, EventArgs e)
        {
            idRolSeleccionado = obtenerIdRolSeleccionado();
            RolAsignado rolAsignado = new RolAsignado(username, idRolSeleccionado);
            rolAsignado.guardate();
            this.busquedaDeValores();
        }

        private void CMBrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CMBrol_CLick(object sender, EventArgs e)
        {
            CMBrol.Items.Clear();
            completarBaseDeRoles();
            completarComboBox();

        }
    }
}
