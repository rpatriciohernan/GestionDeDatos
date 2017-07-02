using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Rol
{
    class RolAsignado
    {


        #region atributos
        private String username;
        private Int16 idRol;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioRolAsignado repositorioRolAsignado = RepositorioRolAsignado.Instance;
        #endregion

        #region constructores
        public RolAsignado(String username, Int16 idRol) {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.username = username;
            this.camposObligatorios.Add(new CampoYValor("username", this.username));

            this.idRol = idRol;
            this.camposObligatorios.Add(new CampoYValor("IdRol", this.idRol.ToString()));
        }
        #endregion

        #region getters y setters
        public Int16 IdRol
        {
            get { return idRol; }
        }
        public string Username
        {
            get { return username; }
        }
        #endregion


        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<RolAsignado> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioRolAsignado.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioRolAsignado.Guardar(this);
        }

        public void eliminate()
        {
            repositorioRolAsignado.Eliminar(this);
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
            return "'" + this.username + "'" + ',' + "'" + Convert.ToString(this.idRol) + "'";
        }
        #endregion

    }
}
