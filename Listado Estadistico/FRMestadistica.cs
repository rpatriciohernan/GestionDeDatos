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
using UberFrba.Abm_Cliente;
using UberFrba.BuilderObjectViews;

namespace UberFrba.Listado_Estadistico
{
    public partial class FRMestadistica : Form
    {
        public FRMestadistica()
        {
            InitializeComponent();
        }


        private String resolverTrimestre() {
            String trimestre = null;
            if (CMBtrimestre.Text == "1: Primer Trimestre"){
                trimestre = "1";
            } else if (CMBtrimestre.Text == "2: Segundo Trimestre"){
                trimestre = "2";
            } else if (CMBtrimestre.Text == "3: Tercer Trimestre")
            {
                trimestre = "3";
            }
            else if (CMBtrimestre.Text == "4: Cuarto Trimestre")
            {
                trimestre = "4";
            }
            return trimestre;
        }

        private Dictionary<String, String> buscarPorTrimestreYAnio() {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("trimestre", resolverTrimestre());
            parametrosDeBusqueda.Add("anio", TXTanio.Text);

            return parametrosDeBusqueda;
        }

        private void render<T>(T lista) {
            BindingSource bs = new BindingSource(lista, "");
            dataGridView1.DataSource = bs;
        }

        private void BTNchoferMayorRecaudacion_Click(object sender, EventArgs e)
        {
            List<ChoferConMayorRecaudacionView> choferes = Chofer.buscarChoferesConMayorRecaudacion(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni,recaudacion
            render(choferes);
        }

        private void BTNchoferViajeLargo_Click(object sender, EventArgs e)
        {
            List<ChoferConViajeMasLargoView> choferes = Chofer.buscarChoferesConViajeMasLargo(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni,kms viaje
            render(choferes);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BTNclienteConsumo_Click(object sender, EventArgs e)
        {
            List<ClienteConMayorConsumoView> clientes = Cliente.buscarClientesConMayorConsumo(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni,consumo
            render(clientes);
        }

        private void BTNclienteUsoMismoAutomovil_Click(object sender, EventArgs e)
        {
            List<ClienteConMayorUsoDeUnAutomovilView> clientes = Cliente.buscarClientesConMayorUsoDeUnMismoAutomovil(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni, patenteAuto, veces de uso
            render(clientes);
        }

        private void FRMestadistica_Load(object sender, EventArgs e)
        {

        }
    }
}
