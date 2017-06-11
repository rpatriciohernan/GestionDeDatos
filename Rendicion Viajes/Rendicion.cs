using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Rendicion_Viajes
{
    class Rendicion
    {
        #region atributos
        private Int16 idRendicion;
        private Int16 idChofer;
        private Int16 idTurno;
        private DateTime fecha;
        private Int16 importe;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioRendicion repositorioRendicion = RepositorioRendicion.Instance;
        #endregion

        #region getters y setters
        public Int16 IdRendicion
        {
            get { return idRendicion; }
        }
        public Int16 IdChofer
        {
            get { return idChofer; }
        }
        public Int16 IdTurno
        {
            get { return idTurno; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
        }
        public Int16 Importe
        {
            get { return importe; }
        }
        #endregion

        #region constructor
        public Rendicion(Int16 idRendicion, Int16 idChofer, Int16 idTurno, DateTime fecha, Int16 importe)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.idRendicion = idRendicion;
            this.camposObligatorios.Add(new CampoYValor("idRendicion", this.idRendicion.ToString()));

            this.idChofer = idChofer;
            this.camposObligatorios.Add(new CampoYValor("idChofer", this.idChofer.ToString()));

            this.idTurno = idTurno;
            this.camposObligatorios.Add(new CampoYValor("idTurno", this.idTurno.ToString()));

            this.fecha = fecha;
            this.camposObligatorios.Add(new CampoYValor("fecha", this.fecha.ToString()));

            this.importe = importe;
            this.camposObligatorios.Add(new CampoYValor("importe", this.importe.ToString()));
        }
        #endregion

        #region constructor
        public Rendicion(Int16 idChofer, Int16 idTurno, DateTime fecha, Int16 importe)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.idChofer = idChofer;
            this.camposObligatorios.Add(new CampoYValor("idChofer", this.idChofer.ToString()));

            this.idTurno = idTurno;
            this.camposObligatorios.Add(new CampoYValor("idTurno", this.idTurno.ToString()));

            this.fecha = fecha;
            this.camposObligatorios.Add(new CampoYValor("fecha", this.fecha.ToString()));

            this.importe = importe;
            this.camposObligatorios.Add(new CampoYValor("importe", this.importe.ToString()));
        }
        #endregion



        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Rendicion> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioRendicion.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioRendicion.Guardar(this);
        }

        public List<ErrorDeCampo> validarCampos()
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }



    }
}
