using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class FRMviajesRegistrados : Form
    {
        public FRMviajesRegistrados()
        {
            InitializeComponent();
        }

        private void FRMviajesRegistrados_Load(object sender, EventArgs e)
        {
            //asociacion de controlador de tipo de datos
            this.TXTdni.KeyPress += TXTdni_KeyPress;

        }

        private void TXTdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            busquedaDeValores();
        }

        private void busquedaDeValores()
        {

            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
          
            if (TXTdni.Text != "")
            {
                if (RBTtipoChofer.Checked) { parametrosDeBusqueda.Add("id_chofer", TXTdni.Text); };
                if (RBTtipoCliente.Checked) { parametrosDeBusqueda.Add("id_cliente", TXTdni.Text); };

                
            }
            List<Viaje> viajes = Viaje.buscar(parametrosDeBusqueda);
            construccionDeGridView(viajes);
        }

        private void construccionDeGridView(object dataSource)
        {
            //asociacion de datagrid con base de datos
            BindingSource bs = new BindingSource(dataSource, "");
            dataGridView1.DataSource = bs;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["IdAutomovil"].Visible = false;
            dataGridView1.Columns["IdTurno"].Visible = false;
            dataGridView1.Columns["IdFactura"].Visible = false;

        }

    }
}
