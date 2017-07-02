using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    class Turno
    {
        #region atributos

        private Int16 idTurno;
        private String descripcion;
        private String estado;
        private String horaInicio; //private DateTime horaInicio;
        private String horaFin; //private DateTime horaFin;
        private Int16 valorKilometro;
        private Int16 precioBase;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioTurno repositorioTurno = RepositorioTurno.Instance;

        #endregion


        #region getters y setters
        public Int16 IdTurno
        {
            get { return idTurno; }
        }
        public string Descripcion
        {
            get { return descripcion; }
        }
        public string Estado    
         {
            get { return estado; }
        }
        public String HoraInicio
        {
            get { return horaInicio; }
        }
        public String HoraFin
        {
            get { return horaFin; }
        }
        public Int16 ValorKilometro
        {
            get { return valorKilometro; }
        }
        public Int16 PrecioBase
        {
            get { return precioBase; }
        }
        #endregion

        #region constructor
        public Turno(Int16 idTurno, String descripcion, String horaInicio, String horaFin, Int16 valorKilometro, Int16 precioBase, String estado)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.idTurno = idTurno;
            this.camposObligatorios.Add(new CampoYValor("idTurno", this.idTurno.ToString()));

            this.descripcion = descripcion;
            this.camposObligatorios.Add(new CampoYValor("Descripcion", this.descripcion));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Apellido", this.estado));

            this.horaInicio = horaInicio;
            this.camposObligatorios.Add(new CampoYValor("HoraInicio", this.horaInicio.ToString()));

            this.horaFin = horaFin;
            this.camposObligatorios.Add(new CampoYValor("HoraFin", this.horaFin.ToString()));

            this.valorKilometro = valorKilometro;
            this.camposObligatorios.Add(new CampoYValor("ValorKilometro", this.valorKilometro.ToString()));

            this.precioBase = precioBase;
            this.camposObligatorios.Add(new CampoYValor("PrecioBase", this.precioBase.ToString()));

        }
        #endregion  
        
        #region constructor
        public Turno(String descripcion, String estado, String horaInicio, String horaFin, Int16 valorKilometro, Int16 precioBase)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.descripcion = descripcion;
            this.camposObligatorios.Add(new CampoYValor("Descripcion", this.descripcion));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Apellido", this.estado));
            
            this.horaInicio = horaInicio;
            this.camposObligatorios.Add(new CampoYValor("HoraInicio", this.horaInicio.ToString()));

            this.horaFin = horaFin;
            this.camposObligatorios.Add(new CampoYValor("HoraFin", this.horaFin.ToString()));

            this.valorKilometro = valorKilometro;
            this.camposObligatorios.Add(new CampoYValor("ValorKilometro", this.valorKilometro.ToString()));

            this.precioBase = precioBase;
            this.camposObligatorios.Add(new CampoYValor("PrecioBase", this.precioBase.ToString()));

        }
        #endregion  
  
        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Turno> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioTurno.buscar(parametrosDeBusqueda);
        }

        public static Turno find(Dictionary<String, String> parametrosDeBusqueda)
        {
            return buscar(parametrosDeBusqueda).First();
        }

        //metodos de instancia
        public void guardate()
        {
            List<Turno> turnosSuperpuestos = repositorioTurno.buscarTurnosSuperpuestos(this);

            if (turnosSuperpuestos.Count > 0)
            {
                MessageBox.Show("La franja horaria seleccionada se superpone con la de otro turno, por favor elija otra");
            } else {
                repositorioTurno.guardar(this);
                MessageBox.Show("El turno se guardo correctamente");
            }
        }

        public void modificate() {
            repositorioTurno.Modificar(this);
        }

        public List<ErrorDeCampo> validarCampos() //devuelve lista de campos obligatorios sin completar
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }


        public String GetValues()
        {
            return "'" + this.descripcion + "'" + ',' + "'" + this.horaInicio + "'" + ',' + "'" +
                Convert.ToString(this.horaFin) + "'" + ',' + "'" + this.valorKilometro + "'" + ',' + "'" +
                Convert.ToString(this.precioBase) + "'" + ',' + "'" + this.estado + "'";
        }
   
    
    
    
    
    
    
    
    
    }


}
