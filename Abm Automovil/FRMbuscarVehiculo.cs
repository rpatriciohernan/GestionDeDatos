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
                parametrosDeBusqueda.Add("cliente_estado", "Activo");
            }
            List<Automovil> clientes = Automovil.buscar(parametrosDeBusqueda);

            BindingSource bs = new BindingSource(clientes, "");
            dataGridView1.DataSource = bs; //bs.ResetBindings(false); hay que hacerlo cada vez que se actualiza la lista
 
        }

        private void FRMbuscarVehiculo_Load(object sender, EventArgs e)
        {
            Dictionary<String, String> searchAll = new Dictionary<string, string>();

            marcas = Marca.buscar(searchAll);
            // turnos = Turno.buscar(searchAll);
            choferes = Chofer.buscar(searchAll);

            //---Atributos que mostramos en los combos---
            marcas.ForEach(marca => CMBmarca.Items.Add(marca.Nombre));

            // turnos.ForEach(turno => CMBturno.Items.Add(turno.Descripcion));

            choferes.ForEach(chofer => CMBChofer.Items.Add(chofer.Nombre));

        }
    }
}
