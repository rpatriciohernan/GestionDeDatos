using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Facturacion
{
    class Facturacion
    {
        private Int16 id;
        private Int16 idCliente;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Int16 importeTotal;
        private static RepositorioFacturacion repositorioFacturacion = RepositorioFacturacion.Instance;

        #region getters y setters
        public Int16 Id
        {
            get { return id; }
        }
        public Int16 IdCliente
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
        public Int16 ImporteTotal
        {
            get { return importeTotal; }
        }
        #endregion

        #region constructores
        public Facturacion(Int16 idCliente, DateTime fechaInicio, DateTime fechaFin, Int16 importeTotal) {
            this.idCliente = idCliente;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.importeTotal = importeTotal;
        }

        public Facturacion(Int16 id,Int16 idCliente, DateTime fechaInicio, DateTime fechaFin, Int16 importeTotal)
        {
            this.idCliente = idCliente;
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

        //metodos de instancia
        public void guardate()
        {
            repositorioFacturacion.Guardar(this);
        }

        public String GetValues()
        { //ojo al agregar nuevos atributo, volcarlos aca!!!
            return "'" + this.idCliente + "'" + ',' + "'" + this.fechaInicio + "'" + ',' + "'" + this.FechaFin + "'" + ',' +
                "'" + this.importeTotal + "'";
        }

    }
}
