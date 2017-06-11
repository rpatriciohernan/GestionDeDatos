using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Bienvenida
{
    class Usuario
    {
        #region atributos
        private String username;
        private String password;
        private Int16 loginFallidos;
        private Int64 dni;
        private String estado;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioUsuario repositorioUsuario = RepositorioUsuario.Instance;
        #endregion
        
        #region constructores
        public Usuario(String username, String password, Int64 dni, String estado) {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.username = username;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.username));

            this.password = password;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.password));

            this.dni = dni;
            this.camposObligatorios.Add(new CampoYValor("Dni", this.dni.ToString()));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.estado));
        }

        public Usuario(String username, String password, Int16 loginFallidos, Int64 dni, String estado)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.username = username;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.username));

            this.password = password;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.password));

            this.dni = dni;
            this.camposObligatorios.Add(new CampoYValor("Dni", this.dni.ToString()));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.estado));

            this.loginFallidos = loginFallidos;
        }
        #endregion

        #region getters y setters
        public Int64 Dni
        {
            get { return dni; }
        }
        public string Password
        {
            get { return password; }
        }
        public string Username
        {
            get { return username; }
        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Usuario> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioUsuario.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioUsuario.Guardar(this);
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
        {
            return "'" + this.username + "'" + ',' + "'" + this.password + "'" + ',' + "'" + Convert.ToString(this.loginFallidos) + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' + "'" + this.estado + "'";
        }
        #endregion
    }
}
