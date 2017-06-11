using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Automovil
{
    class RepositorioAutomovil : Repositorio<Automovil> 
    {

        #region declaracion singleton
        private static RepositorioAutomovil instance;

        private RepositorioAutomovil() { }

        public static RepositorioAutomovil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioAutomovil();
                }
                return instance;
            }
        }
        #endregion


        #region builder del objeto automovil
        public override Automovil BuilderEntityFromDataRow(DataRow dr)
        {
            Automovil automovil = new Automovil(dr[0].ToString(), Convert.ToInt16(dr[1]), Convert.ToInt16(dr[2]), Convert.ToInt16(dr[3]), Convert.ToInt16(dr[4]), dr[5].ToString());
            return automovil;
        }
        #endregion


        public List<Automovil> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Automovil> automovilesEncontrados = SearchManager(query, "overhead.automoviles", 0, 6);
            return automovilesEncontrados;
        }

        public void Guardar(Automovil automovil)
        {
            SqlDataReader dr = queryManager("Insert into overhead.automoviles " + "values(" + automovil.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda) //hacerlo en base a los parametros de busqueda definidos por la consigna
        {
            String queryCondition = "";
            String queryResult = "Select * from overhead.automoviles";
            if (parametrosDeBusqueda.ContainsKey("marca"))
            {
                String marca = parametrosDeBusqueda["marca"];
                queryCondition = "marca = " + "'" + marca + "'" + "'" + " and " + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("modelo"))
            {
                String modelo = parametrosDeBusqueda["modelo"];
                queryCondition = "modelo = " + "'" + modelo + "'" + "'" + " and " + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("patente"))
            {
                String patente = parametrosDeBusqueda["patente"];
                queryCondition = "patente = " + "'" + patente + "'" + "'" + " and " + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("chofer"))
            {
                String chofer = parametrosDeBusqueda["chofer"];
                queryCondition = "chofer = " + "'" + chofer + "'" + "'" + " and " + "'";
            }

            if (queryCondition != "")
            {
                queryCondition = queryCondition.Substring(0, queryCondition.Length - 5);
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }
    }
}
