using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class Cliente
    {
        private String nombre;
        public String apellido;
        private Int64 dni;
        private String mail;
        private String telefono;
        private String direccion;
        private String codigoPostal;
        private DateTime fechaNacimiento;
        private static RepositorioCliente repositorioCliente = RepositorioCliente.Instance;

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
           // this.repositorioCliente = new RepositorioCliente();
        }

        public Boolean validarNombre() {
            return nombre != null;
        }

        public Cliente() {  }

        public static Cliente buscar(Int64 dni) {
            return repositorioCliente.buscar(dni);        
        }

        public String toString() {
            return this.apellido;        
        }


    }
}
