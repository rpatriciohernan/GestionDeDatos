﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    class Marca
    {

        #region atributos
        private Int16 idMarca;
        private String nombre;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioMarca repositorioMarca = RepositorioMarca.Instance;
        #endregion

        #region getters y setters
        public Int16 IdMarca
        {
            get { return idMarca; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        #endregion

        #region constructores
        public Marca(Int16 idMarca, String nombre)
        {
            this.idMarca = idMarca;
            this.nombre = nombre;
        }

        public Marca(String nombre)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.nombre = nombre;
            this.camposObligatorios.Add(new CampoYValor("Nombre", this.nombre));
        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Marca> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioMarca.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioMarca.Guardar(this);
        }

        public List<ErrorDeCampo> validarCampos()
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }

        public String GetValues()
        {
            return "'" + this.nombre + "'";
        }


    }
}
