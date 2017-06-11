using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Funcionalidad
{
    class Funcionalidad
    {
        #region atributos
        private Int16 idFuncionalidad;
        private String nombre;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioFuncionalidad repositorioFuncionalidad = RepositorioFuncionalidad.Instance;
        #endregion 

        #region getters y setters
        public Int16 IdFuncionalidad
        {
            get { return idFuncionalidad; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        #endregion


        
        #region constructor
        public Funcionalidad(Int16 idFuncionalidad, String nombre)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.idFuncionalidad = idFuncionalidad;
            this.camposObligatorios.Add(new CampoYValor("idFuncionalidad", this.idFuncionalidad.ToString()));

            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));

        }
        #endregion

        #region constructor
        public Funcionalidad(String nombre)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));

        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Funcionalidad> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioFuncionalidad.buscar(parametrosDeBusqueda);
        }

        public void guardate()
        {
            repositorioFuncionalidad.guardar(this);
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
            return "'" + this.nombre + "'";
        }
    }
}
