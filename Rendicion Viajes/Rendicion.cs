using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Turno;
using UberFrba.Registro_Viajes;

namespace UberFrba.Rendicion_Viajes
{
    class Rendicion
    {
        #region atributos
        private Int64 idRendicion;
        private Int64 idChofer;
        private Int64 idTurno;
        private DateTime fecha;
        private double importe;

        //atributos solo importantes para la vista
        private double kilometros;
        private double precioBase;
        private double valorKilometro;
        private List<Viaje> viajes;

        private static RepositorioRendicion repositorioRendicion = RepositorioRendicion.Instance;
        #endregion

        #region getters y setters
        public double Kilometros
        {
            get { return kilometros; }
        }
        public double PrecioBase
        {
            get { return precioBase; }
        }
        public double ValorKilometro
        {
            get { return valorKilometro; }
        }
        public List<Viaje> Viajes
        {
            get { return viajes; }
        }


        public Int64 IdRendicion
        {
            get { return idRendicion; }
        }
        public Int64 IdChofer
        {
            get { return idChofer; }
        }
        public Int64 IdTurno
        {
            get { return idTurno; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
        }
        public double Importe
        {
            get { return importe; }
        }
        #endregion

        #region constructor
        public Rendicion(Int64 idRendicion, Int64 idChofer, Int64 idTurno, DateTime fecha, double importe)
        {
            this.idRendicion = idRendicion;
            this.idChofer = idChofer;
            this.idTurno = idTurno;
            this.fecha = fecha;
            this.importe = importe;
        }
        #endregion

        #region constructor
        public Rendicion(Int64 idChofer, Int64 idTurno, DateTime fecha, double importeTotal, double kilometros, double precioBase, double valorKilometro, List<Viaje> viajes)
        {
            this.idChofer = idChofer;
            this.idTurno = idTurno;
            this.fecha = fecha;
            this.importe = importeTotal;

            this.kilometros = kilometros;
            this.precioBase = precioBase;
            this.valorKilometro = valorKilometro;
            this.viajes = viajes;
        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Rendicion> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioRendicion.buscar(parametrosDeBusqueda);
        }

        public static Rendicion calcularRendicion(Dictionary<String, String> parametrosDeBusqueda)
        {
            //chekear que el chofer este activo
            Int64 idChofer = Convert.ToInt64(parametrosDeBusqueda["id_chofer"]);
            Int64 idTurno = Convert.ToInt64(parametrosDeBusqueda["id_turno"]);
            DateTime fecha = Convert.ToDateTime(parametrosDeBusqueda["fecha"]);

            //viajes --> buscar por idChofer, idTurno y fecha
            List<Viaje> viajes = Viaje.buscar(parametrosDeBusqueda);

            double importeTotal = viajes.Sum(viaje => viaje.calcularMonto());
            double kilometros = viajes.Sum(viaje => viaje.CantidadKilometros);

            //turno --> buscar idTurno
            Dictionary<String, String> busquedaTurno = new Dictionary<string, string>();
            busquedaTurno.Add("id_turno", idTurno.ToString());

            Turno turno = Turno.find(busquedaTurno);
            double precioBase = turno.PrecioBase;
            double valorKilometro = turno.ValorKilometro;

            return new Rendicion(idChofer, idTurno, fecha, importeTotal, kilometros, precioBase, valorKilometro, viajes);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioRendicion.Guardar(this);
        }

        

        public String GetValues() //Solo lo que queremos que se escriba en la base
        {
            return "'" + Convert.ToString(this.idChofer) + "'" + ',' + "'" + Convert.ToString(this.idTurno) + "'" + ',' + "'" + Convert.ToString(this.fecha) + "'" + ',' + "'" + Convert.ToString(this.importe);
        }

    }
}
