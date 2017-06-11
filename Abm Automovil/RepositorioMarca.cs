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
    class RepositorioMarca : Repositorio<Marca>
    {
        #region declaracion singleton
        private static RepositorioMarca instance;

        private RepositorioMarca() { }

        public static RepositorioMarca Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioMarca();
                }
                return instance;
            }
        }
        
        #endregion

       #region builder del objeto cliente
        public override Marca BuilderEntityFromDataRow(DataRow dr)
        {
            Marca marca = new Marca(Convert.ToInt16(dr[0]) , dr[1].ToString());
            return marca;
        }
        #endregion

        public List<Marca> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Marca> marcasEncontradas = SearchManager(query, "Marcas", 0, 6);
            return marcasEncontradas;
        }

        public void Guardar(Marca marca)
        {
            SqlDataReader dr = queryManager("Insert into overhead.marcas " + "values(" + marca.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda) {
            String queryCondition = "";
            String queryResult = "Select * from overhead.marcas";
            if (parametrosDeBusqueda.ContainsKey("idMarca"))
            {
                String idMarca = parametrosDeBusqueda["idMarca"];
                queryCondition = "idMarca = " + "'" + idMarca + "'";
            }
            
            if (parametrosDeBusqueda.ContainsKey("nombre")) {
                String nombre = parametrosDeBusqueda["nombre"];
                queryCondition = "nombre = " + "'" + nombre + "'";
            }

            if (queryCondition != "") {
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }
        


    }

    }
