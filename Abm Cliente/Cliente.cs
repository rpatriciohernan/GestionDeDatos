using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class Cliente
    {
        #region atributos
        private String nombre;
        private String apellido;
        private Int64 dni;
        private String mail;
        private String telefono;
        private String direccion;
        private String codigoPostal;
        private DateTime fechaNacimiento;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioCliente repositorioCliente = RepositorioCliente.Instance;
        #endregion

        #region getters y setters
        public string Nombre
        {
            get { return nombre; }
        }
        public string Apellido
        {
            get { return apellido; }
        }
        public Int64 Dni
        {
            get { return dni; }
        }
        public string Mail
        {
            get { return mail; }
        }
        public string Telefono
        {
            get { return telefono; }
        }
        public string Direccion
        {
            get { return direccion; }
        }
        public string CodigoPostal
        {
            get { return codigoPostal; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
        }
        #endregion

        #region constructor
        public Cliente(String nombre, String apellido, Int64 dni, String mail, String telefono,
            String direccion, String codigoPostal, DateTime fechaNacimiento)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));

            this.apellido = apellido;
            this.camposObligatorios.Add(new CampoYValor("Apellido", this.apellido));
            
            this.dni = dni;
            this.camposObligatorios.Add(new CampoYValor("Dni", this.dni.ToString()));
           
            this.mail = mail;
            this.camposObligatorios.Add(new CampoYValor("Mail", this.mail));
           
            this.telefono = telefono;
            this.camposObligatorios.Add(new CampoYValor("Telefono", this.telefono));
            
            this.direccion = direccion;
            this.camposObligatorios.Add(new CampoYValor("Direccion", this.direccion));
           
            this.codigoPostal = codigoPostal;
            this.camposObligatorios.Add(new CampoYValor("CodigoPostal", this.codigoPostal));
            
            this.fechaNacimiento = fechaNacimiento;
            this.camposObligatorios.Add(new CampoYValor("FechaNacimiento", Convert.ToString(this.fechaNacimiento)));
        }
        #endregion
        
        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static Cliente buscar(Int64 dni)
        {
            return repositorioCliente.buscar(dni);
        }

        //metodos de instancia
        public void guardate() {
            repositorioCliente.Guardar(this);
        }

        public List<ErrorDeCampo> validarCampos() { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo,"falta completar")).ToList();
            return errores;
        }

        public Boolean validarNombre() { //era de prueba, borrarlo
            return nombre != null;
        }

        public String toString() { //era de prueba, borrarlo
            return this.apellido;        
        }

        public String GetValues() { //ojo al agregar nuevos atributo, volcarlos aca!!!
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' +
                "'" + this.mail + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" + this.direccion + "'" + ',' + "'" + this.codigoPostal + "'" + ',' + "'" + Convert.ToString(this.fechaNacimiento) + "'";
        }

    }
}
