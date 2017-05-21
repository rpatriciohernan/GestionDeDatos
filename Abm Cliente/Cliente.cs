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
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            this.telefono = telefono;
            this.direccion = direccion;
            this.codigoPostal = codigoPostal;
            this.fechaNacimiento = fechaNacimiento;
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

        public List<ErrorDeCampo> validarCampos() { 
            
            List<ErrorDeCampo> errores = new List<ErrorDeCampo>();

            if (dni == null) {
                errores.Add(new ErrorDeCampo("dni", "falta completar"));
            }

            return errores;
        }

        public Boolean validarNombre() {
            return nombre != null;
        }

        public String toString() {
            return this.apellido;        
        }

        public String GetValues() {
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' +
                "'" + this.mail + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" + this.direccion + "'" + ',' + "'" + this.codigoPostal + "'" + ',' + "'" + Convert.ToString(this.fechaNacimiento) + "'";
        }

    }
}
