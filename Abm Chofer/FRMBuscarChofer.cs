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

        }

        private void BTNbuscar_Click(object sender, EventArgs e)
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

            List<Chofer> choferes = Chofer.buscar(parametrosDeBusqueda);

            BindingSource bs = new BindingSource(choferes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false); hay que hacerlo cada vez que se actualiza la lista
        }
    }
}
