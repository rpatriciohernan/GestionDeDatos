using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Registro_Viajes;

namespace UberFrba.Facturacion
{
    class Facturacion
    {
        private Int16 id;
        private Int64 idCliente;
        private DateTime fechaCreacion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private double importeTotal;

        private List<Viaje> viajes;
        private static RepositorioFacturacion repositorioFacturacion = RepositorioFacturacion.Instance;

        #region getters y setters
        public Int16 Id
        {
            get { return id; }
        }
        public Int64 IdCliente
        {
            get { return idCliente; }
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
        }
        public DateTime FechaFin
        {
            get { return fechaFin; }
        }
        public double ImporteTotal
        {
            get { return importeTotal; }
        }
        public List<Viaje> Viajes
        {
            get { return viajes; }
        }
        #endregion

        #region constructores
        public Facturacion(Int64 idCliente, DateTime fechaInicio, DateTime fechaFin, double importeTotal, List<Viaje> viajes)
        {
            this.idCliente = idCliente;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.importeTotal = importeTotal;
            this.viajes = viajes;
        }

        public Facturacion(Int64 idCliente, DateTime fechaInicio, DateTime fechaFin, double importeTotal)
        {
            this.idCliente = idCliente;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.importeTotal = importeTotal;
        }

        public Facturacion(Int16 id, DateTime fechaCreacion, Int64 idCliente, DateTime fechaInicio, DateTime fechaFin, double importeTotal)
        {
            this.idCliente = idCliente;
            this.fechaCreacion = fechaCreacion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.importeTotal = importeTotal;
            this.id = id;
        }
        #endregion


        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Facturacion> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioFacturacion.buscar(parametrosDeBusqueda);
        }

        public static Facturacion facturarIntervalo(Dictionary<String, String> parametrosDeBusqueda)
        {
            List<Viaje> viajes = Viaje.buscar(parametrosDeBusqueda); //pulir esto, hacer bien la logica para las fechas

            //aca se le deberia decir a los viajes que se guarden el id de la factura

            double importeTotal = viajes.Sum(viaje => viaje.calcularMonto());

            //feoooo ver como arreglarlo
            String[] fechas = parametrosDeBusqueda["entreFechas"].Split('&');
            String fechaInicio = fechas[0];
            String fechaFinal = fechas[1];

            return new Facturacion(Convert.ToInt16(parametrosDeBusqueda["id_cliente"]), Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFinal), importeTotal, viajes);
        }

        //metodos de instancia
        public void guardate()
        {
           Facturacion facturacionStored = repositorioFacturacion.Guardar(this);
           this.viajes.ForEach(viaje =>
               {
               viaje.setIdFactura(facturacionStored.Id);
               viaje.modificate();
               });
        }

        public String GetValues()
        { //ojo al agregar nuevos atributo, volcarlos aca!!!
            String fechaCreacion = DateTime.Now.ToString();
            return "'" + fechaCreacion + "'" + ',' + "'" + this.idCliente + "'" + ',' + "'" + this.fechaInicio + "'" + ',' + "'" + this.FechaFin + "'" + ',' +
                "'" + this.importeTotal + "'";
        }
    }
}
