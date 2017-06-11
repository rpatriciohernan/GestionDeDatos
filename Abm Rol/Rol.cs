using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Rol
{
    class Rol
    {
        #region atributos
        private Int16 id;
        String nombre;
        String estado;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioRol repositorioRol = RepositorioRol.Instance;
        #endregion

        #region constructores
        public Rol(String nombre, String estado) {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.nombre));
        }

        public Rol(Int16 id, String nombre, String estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
        }
        #endregion

        #region getters y setters
        public Int16 Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public string Estado
        {
            get { return estado; }
        }
        #endregion


        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Rol> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioRol.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioRol.Guardar(this);
        }

        public List<ErrorDeCampo> validarCampos()
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }

        #region values
        public String GetValues()
        { //ojo al agregar nuevos atributo, volcarlos aca!!!
            return "'" + this.id + "'" + ',' + "'" + this.nombre + "'" + ',' + "'" + this.estado + "'";
        }
        #endregion
    }
}
