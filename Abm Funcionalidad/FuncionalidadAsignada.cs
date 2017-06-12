using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Funcionalidad
{
    class FuncionalidadAsignada
    {

        #region atributos
        private Int16 idFuncionalidad;
        private Int16 idRol;
        private List<CampoYValor> camposObligatorios;
        private static RepositorioFuncionalidadAsignada repositorioFuncionalidadAsignada = RepositorioFuncionalidadAsignada.Instance;
        #endregion

        #region getters y setters
        public Int16 IdFuncionalidad
        {
            get { return idFuncionalidad; }
        }
        public Int16 IdRol
        {
            get { return idRol; }
        }
        #endregion

       #region constructor
        public FuncionalidadAsignada(Int16 idRol, Int16 idFuncionalidad)
        {
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();
            
            this.idFuncionalidad = idFuncionalidad;
            this.camposObligatorios.Add(new CampoYValor("idFuncionalidad", this.idFuncionalidad.ToString()));

            this.idRol = idRol;
            this.camposObligatorios.Add(new CampoYValor("idRol", this.idRol.ToString()));

        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<FuncionalidadAsignada> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioFuncionalidadAsignada.buscar(parametrosDeBusqueda);
        }

        public void guardate()
        {
            repositorioFuncionalidadAsignada.guardar(this);
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
            return "'" + this.idRol.ToString() + "'" + "," + "'" + this.idFuncionalidad.ToString() + "'";
        }

    }
}
