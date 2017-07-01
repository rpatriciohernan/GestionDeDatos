using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Turno;

namespace UberFrba.Registro_Viajes
{
    class Viaje
    {
        private Int16 id;
        private Int16 idChofer;
        private String idAutomovil;
        private Int16 idTurno;
        private Double cantidadKilometros;
        private DateTime inicio;
        private DateTime fin;
        private Int16 idFactura; //vamos a hacer las facturas calculables, asi que setteamos este id una vez que se haya creado la factura
        private Int16 idCliente;

        private double monto;
        private static RepositorioViaje repositorioViaje = RepositorioViaje.Instance;


        #region getters y setters
        public Int16 Id
        {
            get { return id; }
        }
        public Int16 IdChofer
        {
            get { return idChofer; }
        }
        public String IdAutomovil
        {
            get { return idAutomovil; }
        }
        public Int16 IdTurno
        {
            get { return idTurno; }
        }
        public Double CantidadKilometros
        {
            get { return cantidadKilometros; }
        }
        public DateTime Inicio
        {
            get { return inicio; }
        }
        public DateTime Fin
        {
            get { return fin; }
        }
        public Int16 IdFactura
        {
            get { return idFactura; }
        }
        public Int16 IdCliente
        {
            get { return idCliente; }
        }
        public double Monto
        {
            get { return monto; }
        }
        #endregion

        #region constructores
        public Viaje(Int16 id, Int16 idChofer, String idAutomovil, Int16 idTurno, Double cantidadKilometros, DateTime inicio, DateTime fin, Int16 idCliente, Int16 idFactura)
        {
            this.id = id;
            this.idChofer = idChofer;
            this.idAutomovil = idAutomovil;
            this.idTurno = idTurno;
            this.cantidadKilometros = cantidadKilometros;
            this.inicio = inicio;
            this.fin = fin;
            this.idFactura = idFactura;
            this.idCliente = idCliente;
        }

        public Viaje(Int16 idChofer, String idAutomovil, Int16 idTurno, Double cantidadKilometros, DateTime inicio, DateTime fin, Int16 idCliente, Int16 idFactura)
        {
            this.idChofer = idChofer;
            this.idAutomovil = idAutomovil;
            this.idTurno = idTurno;
            this.cantidadKilometros = cantidadKilometros;
            this.inicio = inicio;
            this.fin = fin;
            this.idFactura = idFactura;
            this.idCliente = idCliente;
        }
        #endregion constructor


        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Viaje> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioViaje.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioViaje.Guardar(this);
        }

        public double calcularMonto() //le pegamos a la base por cada viaje, no es lo mas copado, pero por ahora lo dejamos asi :/
        { 
            //supongo que el monto es el precioBase del turno + (precioDelKilometro x cantKilometrosRecorridos)
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<String, String>();
            parametrosDeBusqueda.Add("id_turno", idTurno.ToString());

            Turno turno = Turno.find(parametrosDeBusqueda);

            double monto = turno.PrecioBase + turno.ValorKilometro * this.cantidadKilometros;
            this.monto = monto; //para que el viajeView tenga el monto
            return monto;
        }


        #region values
        public String GetValues()
        { //ojo al agregar nuevos atributo, volcarlos aca!!! , EL iD NO VA se genera automaticamente ;)
            return "'" + this.idChofer + "'" + ',' + "'" + this.idAutomovil + "'" + ',' +
                "'" + this.idTurno + "'" + ',' + "'" + this.cantidadKilometros + "'" + ',' + "'" + this.inicio + "'" + ',' +
                "'" + this.fin + "'" + ',' + "'" + this.idCliente + "'" + ',' + "'" + this.idFactura + "'";
        #endregion



        }




    }
}
