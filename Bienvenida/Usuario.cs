using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Rol;

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
        private List<Rol> rolesAsignados = new List<Rol>();
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


        public List<String> RolesAsignados()
        {
            List<String> nombreDeRoles = new List<String>();
            this.ActualizarRoles();
            rolesAsignados.ForEach(rol => nombreDeRoles.Add(rol.Nombre));
            return nombreDeRoles;

        }

        private void ActualizarRoles()
        {
            //busco los roles asignados del usuario en la tabla intermedia roles_asignados
            Dictionary<String, String> parametrosBusquedaRolesAsignados = new Dictionary<String, String>();
            parametrosBusquedaRolesAsignados.Add("username", this.username);
            List<RolAsignado> rolesAsignadosEncontrados = RolAsignado.buscar(parametrosBusquedaRolesAsignados);
            
            //con los roles encontrados, cargo la entidad de rol en la tabla Rol
            rolesAsignadosEncontrados.ForEach(rolAsignado => this.CargarRolDeUsuario(rolAsignado.IdRol));

        }

        private void CargarRolDeUsuario(Int16 idRol)
        {
            Dictionary<String, String> parametrosBusquedaRoles = new Dictionary<String, String>();
            parametrosBusquedaRoles.Add("id_rol", idRol.ToString());
            if (Rol.buscar(parametrosBusquedaRoles).Count > 0)
            {
                rolesAsignados.Add(Rol.buscar(parametrosBusquedaRoles).First());
            }
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
