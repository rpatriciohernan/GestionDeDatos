using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Funcionalidad
{
    class RepositorioFuncionalidad : Repositorio<Funcionalidad>
    {
      #region declaracion singleton
        private static RepositorioFuncionalidad instance;

        private RepositorioFuncionalidad() { }

        public static RepositorioFuncionalidad Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioFuncionalidad();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto
        public override Funcionalidad BuilderEntityFromDataRow(DataRow dr)
        {
            Funcionalidad funcionalidad = new Funcionalidad(Convert.ToInt16(dr[0]), dr[1].ToString());
            return funcionalidad;
        }
        #endregion

        public List<Funcionalidad> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Funcionalidad> funcionalidadesEncontradas = SearchManager(query, "Funcionalidades", 0, 6);
            return funcionalidadesEncontradas;
        }

        public void guardar(Funcionalidad funcionalidad)
        {
            SqlDataReader dr = queryManager("Insert into overhead.funcionalidades " + "values(" + funcionalidad.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda)
        {
            String queryCondition = "";
            String queryResult = "Select * from overhead.funcionalidades";
            if (parametrosDeBusqueda.ContainsKey("idFuncionalidad"))
            {
                String idFuncionalidad = parametrosDeBusqueda["idFuncionalidad"];
                queryCondition = "ID_FUNCIONALIDAD = " + "'" + idFuncionalidad + "'";
            }
            if (parametrosDeBusqueda.ContainsKey("nombre"))
            {
                String nombre = parametrosDeBusqueda["nombre"];
                queryCondition = "nombre = " + "'" + nombre + "'";
            }

            if (queryCondition != "")
            {
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }    
    }
}
