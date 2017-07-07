using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;
using UberFrba.BuilderObjectViews;
using UberFrba.Registro_Viajes;

namespace UberFrba.Facturacion
{
    public partial class FRMfacturacion : Form
    {
        private List<Cliente> clientes;
        private Int64 idCliente;
        private Facturacion facturacion;
        DateTime fechaInicio;
        DateTime fechaFin;

        public FRMfacturacion()
        {
            InitializeComponent();
        }

        private Int64 getIdClienteSeleccionado()
        {//si hay 2 clientes con mismo nombre y apellido no funciona -> habria que hacerlo por posicion del combo, mostrando en el combo el nombre, apellido y dni ;)!!
            return clientes.Find(cliente => cliente.Nombre + ", " + cliente.Apellido == CMBcliente.Text).Dni;
        }

        private void BTNgenerar_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> parametrosDeFacturacion = new Dictionary<string, string>();

            //obtenemos el id de los datos de los combos, ya que provienen de otras tablas
            idCliente = getIdClienteSeleccionado(); //el idCliente lo dejamos fijo al momento de generar la factura entonces, si despues se cambia. Al momento de cargar la factura se toma con el que se genero
            fechaInicio = Convert.ToDateTime(DTEinicio.Text);
            fechaFin = Convert.ToDateTime(DTEfin.Text);
            
            parametrosDeFacturacion.Add("id_cliente", idCliente.ToString());
            
            parametrosDeFacturacion.Add("entreFechas", fechaInicio + "&" + fechaFin); //"01/06/2017&30/06/2017"); el viaje sabe solo como buscar esto

            facturacion = Facturacion.facturarIntervalo(parametrosDeFacturacion); 

            txtImporteTotal.Text = facturacion.ImporteTotal.ToString();

            mostrarViajes();
        }

        private void mostrarViajes()
        {
            List<Viaje> viajes = facturacion.Viajes;
            List<ViajeView> viajesViews = viajes.Select(viaje => BuilderObjectView.Instance.createViajeViewFromViaje(viaje)).ToList(); //dados los viajes normales, creamos los viajesViews que son mas copados de vista al usuario. Al usuario no le interesa ver ids y demas
            BindingSource bs = new BindingSource(viajesViews, "");
            dataGridView1.DataSource = bs; 
        }

        private void FRMfacturacion_Load(object sender, EventArgs e)
        {
            Dictionary<String, String> searchAllClientes = new Dictionary<string, string>();
            searchAllClientes.Add("cliente_estado", "Activo");
            clientes = Cliente.buscar(searchAllClientes);

            //---Atributos que mostramos en los combos---
            clientes.ForEach(cliente => CMBcliente.Items.Add(cliente.Nombre + ", " + cliente.Apellido));
        }

        private void BTNcargar_Click(object sender, EventArgs e)
        {
            facturacion.guardate();
        }

        private Facturacion crearFacturacion() {
            return new Facturacion(idCliente, fechaInicio, fechaFin, Convert.ToDouble(txtImporteTotal.Text));
        }
    }
}
