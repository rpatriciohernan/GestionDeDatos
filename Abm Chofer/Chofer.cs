﻿using System;
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
         private String calle;
         private Int16 numero;
         private Int16 piso;
         private String departamento;
         private String localidad;
         private String telefono;
         private String mail;
         private DateTime fechaNacimiento;
         private String estado;
         private List<CampoYValor> camposObligatorios;
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
         public string Calle
         {
             get { return calle; }
         }
         public Int16 Numero
         {
             get { return numero; }
         }
         public Int16 Piso
         {
             get { return piso; }
         }
         public string Departamento
         {
             get { return departamento; }
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
        public Chofer(String nombre, String apellido, Int64 dni, String calle, Int16 numero, Int16 piso, String departamento, String localidad, String telefono, String mail, DateTime fechaNacimiento, String estado)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));

            this.apellido = apellido;
            this.camposObligatorios.Add(new CampoYValor("Apellido", this.apellido));
            
            this.dni = dni;
            this.camposObligatorios.Add(new CampoYValor("Dni", this.dni.ToString()));

            this.calle = calle;
            this.camposObligatorios.Add(new CampoYValor("Calle", this.calle));

            this.numero = numero;
            this.camposObligatorios.Add(new CampoYValor("Numero", this.numero.ToString()));

            this.piso = piso;

            this.departamento = departamento;

            this.localidad = localidad;
            this.camposObligatorios.Add(new CampoYValor("Localidad", this.localidad));

            this.telefono = telefono;
            this.camposObligatorios.Add(new CampoYValor("Mail", this.telefono));

            this.mail = mail;
            this.camposObligatorios.Add(new CampoYValor("Mail", this.mail));

            this.fechaNacimiento = fechaNacimiento;
            this.camposObligatorios.Add(new CampoYValor("FechaNacimiento", this.fechaNacimiento.ToString()));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.estado));
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

        public List<ErrorDeCampo> validarCampos() //devuelve lista de campos obligatorios sin completar
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }


        public String GetValues()
        {
            return "'" + this.nombre + "'" + ',' + "'" + this.apellido + "'" + ',' + "'" + Convert.ToString(this.dni) + "'" + ',' + "'" + this.calle + "'" + ',' + "'" + Convert.ToString(this.numero) + "'" + ',' + "'" + Convert.ToString(this.piso) + "'" + ',' + "'" + this.departamento + "'" + ',' + "'" + this.localidad + "'" + ',' + "'" + this.telefono + "'" + ',' + "'" + this.mail + "'" + ',' + "'" + Convert.ToString(this.fechaNacimiento) + "'" + ',' + "'" + this.estado + "'";
        }


     }
}