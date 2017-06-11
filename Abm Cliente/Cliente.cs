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
     
        private String calle;
        private Int16 numero;
        private String piso;
        private String depto;

        private String localidad;

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
        public string Calle
        {
            get { return calle; }
        }
        public Int16 Numero
        {
            get { return numero; }
        }
        public string Piso
        {
            get { return piso; }
        }
        public string Depto
        {
            get { return depto; }
        }
        public string Localidad
        {
            get { return localidad; }
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
            String calle, Int16 numero, String piso, String depto, String localidad, String codigoPostal, DateTime fechaNacimiento)
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

            this.calle = calle;
            this.camposObligatorios.Add(new CampoYValor("Calle", this.calle));

            this.numero = numero;
            this.camposObligatorios.Add(new CampoYValor("Numero", this.numero.ToString()));

            this.piso = piso;
            this.camposObligatorios.Add(new CampoYValor("Piso", this.piso));

            this.depto = depto;
            this.camposObligatorios.Add(new CampoYValor("Depto", this.depto));

            this.localidad = localidad;
            this.camposObligatorios.Add(new CampoYValor("Localidad", this.localidad));
           
            this.codigoPostal = codigoPostal;
            this.camposObligatorios.Add(new CampoYValor("CodigoPostal", this.codigoPostal));
            
            this.fechaNacimiento = fechaNacimiento;
            this.camposObligatorios.Add(new CampoYValor("FechaNacimiento", Convert.ToString(this.fechaNacimiento)));
        }
        #endregion
        
        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Cliente> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioCliente.buscar(parametrosDeBusqueda);
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

        public String GetValues() { //ojo al agregar nuevos atributo, volcarlos aca!!!
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' +
                "'" + this.mail + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" + this.calle + "'" + ',' + 
                "'" + this.numero.ToString() + "'" + ',' + "'" + this.piso + "'" + ',' + "'" + this.depto + "'" + ',' + 
                "'" + this.localidad + "'" + ',' + "'" + this.codigoPostal + "'" + ',' + "'" + Convert.ToString(this.fechaNacimiento) + "'";
        }

    }
}
