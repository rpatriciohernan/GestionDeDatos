using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Facturacion
{
    public partial class FRMmisFacturaciones : Form
    {
        public FRMmisFacturaciones()
        {
            InitializeComponent();
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

        private void FRMmisFacturaciones_Load(object sender, EventArgs e)
        {
            //asociacion de controlador de tipo de datos
            this.TXTdni.KeyPress += TXTdni_KeyPress;

        }

        private void busquedaDeValores()
        {

            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            if (TXTdni.Text != "")
            {
                parametrosDeBusqueda.Add("id_cliente", TXTdni.Text);
            }
            List<Facturacion> viajes = Facturacion.buscar(parametrosDeBusqueda);
            construccionDeGridView(viajes);
        }


        private void construccionDeGridView(object dataSource)
        {
            //asociacion de datagrid con base de datos
            BindingSource bs = new BindingSource(dataSource, "");
            dataGridView1.DataSource = bs;
            dataGridView1.RowHeadersVisible = false;

        }
    }
}
