using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
     class Chofer
     {
        #region atributos
         private String nombre;
         private String apellido;
         private Int64 dni;
         private String domicilio;
         private String localidad;
         private String telefono;
         private String mail;
         private DateTime fechaNacimiento;
         private String estado;
         private static RepositorioChofer repositorioChofer = RepositorioChofer.Instance;

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
         public string Domicilio
         {
             get { return domicilio; }
         }
         public string Locaildad
         {
             get { return localidad; }
         }
         public string Telefono
         {
             get { return telefono; }
         }
         public DateTime FechaNacimiento
         {
             get { return fechaNacimiento; }
         }
         public String Estado
         {
             get { return estado; }
         }
       #endregion


         #region constructor
         public Chofer(String nombre, String apellido, Int64 dni, String domicilio, String localidad, String telefono, String mail, DateTime fechaNacimiento, String estado)
        {
            this.nombre = nombre;

            this.apellido = apellido;
            
            this.dni = dni;

            this.domicilio = domicilio;

            this.localidad = localidad;

            this.telefono = telefono;

            this.mail = mail;

            this.fechaNacimiento = fechaNacimiento;

            this.estado = estado;
        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Chofer> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioChofer.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioChofer.guardar(this);
        }

        public void modificate()
        {
            repositorioChofer.Modificar(this);
        }

        public void eliminate()
        {
            this.estado = "Inactivo";
            repositorioChofer.Modificar(this);
        }

        public String GetValues()
        {
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' 
                + "'" + this.domicilio + "'" + ',' + "'" + this.localidad + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" 
                + this.mail + "'" + ',' + "'" + Convert.ToString(this.fechaNacimiento) + "'" + ',' + "'" + this.estado + "'";
        }
     }
}
