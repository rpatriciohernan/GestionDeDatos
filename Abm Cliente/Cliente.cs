﻿using System;
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
        private String domicilio;
        private Int16 codigoPostal;
        private String localidad;
        private DateTime fechaNacimiento;
        private String estado;
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
        public string Domicilio
        {
            get { return domicilio; }
        }
        public Int16 CodigoPostal
        {
            get { return codigoPostal; }
        }
        public String Localidad
        {
            get { return localidad; }
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
        public Cliente(String nombre, String apellido, Int64 dni, String mail, String telefono,
            String domicilio, Int16 codigoPostal, String localidad, DateTime fechaNacimiento, String estado)
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

            this.domicilio = domicilio;
            this.camposObligatorios.Add(new CampoYValor("Domicilio", this.domicilio));
            
            this.localidad = localidad;
            this.camposObligatorios.Add(new CampoYValor("Localidad", this.localidad));
  
            this.codigoPostal = codigoPostal;
            this.camposObligatorios.Add(new CampoYValor("CodigoPostal", this.codigoPostal.ToString()));
            
            this.fechaNacimiento = fechaNacimiento;
            this.camposObligatorios.Add(new CampoYValor("FechaNacimiento", Convert.ToString(this.fechaNacimiento)));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.estado));
        
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

        public String GetValues()
        {
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ','
                + "'" + this.mail + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" + this.domicilio + "'" + ','
                + "'" + Convert.ToString(this.codigoPostal) + "'" + ',' + "'" + this.localidad + "'" + ',' 
                + "'" + Convert.ToString(this.fechaNacimiento) + "'" + ',' + "'" + this.estado + "'";
        }

    }
}
