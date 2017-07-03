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
             if (this.ValidarCamposMandatorios())
            {
            List<ChoferConMayorRecaudacionView> choferes = Chofer.buscarChoferesConMayorRecaudacion(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni,recaudacion
            render(choferes);
                        }
            else
            {
                this.MensajeError();
            };
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTanio.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBtrimestre.Text)) { validado = false; }

            return validado;

        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNchoferViajeLargo_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                List<ChoferConViajeMasLargoView> choferes = Chofer.buscarChoferesConViajeMasLargo(buscarPorTrimestreYAnio());
            //mostar -> nombre,apellido,dni,kms viaje
            render(choferes);
            }
            else
            {
                this.MensajeError();
            };
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BTNclienteConsumo_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                List<ClienteConMayorConsumoView> clientes = Cliente.buscarClientesConMayorConsumo(buscarPorTrimestreYAnio());
                //mostar -> nombre,apellido,dni,consumo
                render(clientes);
            }
            else
            {
                this.MensajeError();
            }; 
        }

        private void BTNclienteUsoMismoAutomovil_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                List<ClienteConMayorUsoDeUnAutomovilView> clientes = Cliente.buscarClientesConMayorUsoDeUnMismoAutomovil(buscarPorTrimestreYAnio());
                //mostar -> nombre,apellido,dni, patenteAuto, veces de uso
                render(clientes);
            }
            else
            {
                this.MensajeError();
            }; 

        }

        private void TXTanio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void FRMestadistica_Load(object sender, EventArgs e)
        {
            //asociacion de controlador de tipo de datos
            this.TXTanio.KeyPress += TXTanio_KeyPress;

        }
    }
}
