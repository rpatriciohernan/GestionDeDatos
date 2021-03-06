﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.BuilderObjectViews;

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
        private String codigoPostal;
        private String localidad;
        private DateTime fechaNacimiento;
        private String estado;
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
        public String CodigoPostal
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
            String domicilio, String codigoPostal, String localidad, DateTime fechaNacimiento, String estado)
        {            
            this.nombre = nombre;

            this.apellido = apellido;
            
            this.dni = dni;
           
            this.mail = mail;
           
            this.telefono = telefono;

            this.domicilio = domicilio;
            
            this.localidad = localidad;
  
            this.codigoPostal = codigoPostal;
            
            this.fechaNacimiento = fechaNacimiento;

            this.estado = estado;
        
        }
        #endregion
        
        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Cliente> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioCliente.buscar(parametrosDeBusqueda);
        }

        // en vez de devolver un Cliente, devuelve un ClienteConMayorConsumoView
        public static List<ClienteConMayorConsumoView> buscarClientesConMayorConsumo(Dictionary<String, String> parametrosDeBusqueda)
        {
            RepositorioClienteConMayorConsumo repositorioClienteConMayorConsumo = RepositorioClienteConMayorConsumo.Instance;
            return repositorioClienteConMayorConsumo.buscar(parametrosDeBusqueda);
        }

        // en vez de devolver un Cliente, devuelve un ClienteConMayorUsoDeUnAutomovilView
        public static List<ClienteConMayorUsoDeUnAutomovilView> buscarClientesConMayorUsoDeUnMismoAutomovil(Dictionary<String, String> parametrosDeBusqueda) 
        {
            RepositorioClienteConMayorUsoDeUnMismoAutomovil repositorioClienteConMayorUsoDeUnMismoAutomovil = RepositorioClienteConMayorUsoDeUnMismoAutomovil.Instance;
            return repositorioClienteConMayorUsoDeUnMismoAutomovil.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate() {
            repositorioCliente.Guardar(this);
        }

        public void modificate() {
            repositorioCliente.Modificar(this);
        }

        public void eliminate()
        {
            this.estado = "Inactivo";
            repositorioCliente.Modificar(this);
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
