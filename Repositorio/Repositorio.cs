using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Abm_Cliente
{
    abstract class Repositorio<T> 
    {
        /*
         * 
         * OJO, es raro que alla que tocar esta clase!!!! 
         * 
         */

        protected SqlDataReader queryManager(String query)
        {
            SqlCommand cmd = new SqlCommand(query, Conexion.getConnection());
            return cmd.ExecuteReader();
        }


        protected List<T> SearchManager(String query, String table, int numeroDePagina, int tamanioDePagina)
        {
            int pageNumber = numeroDePagina * tamanioDePagina; //el principio de todo es cero (0)
            string orderSQL = query;

            SqlDataAdapter adapter = new SqlDataAdapter(orderSQL, Conexion.getConnection());

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, pageNumber, tamanioDePagina, table); //pageNumber seria el indice en donde se empieza a barrer, tamanioDePagina cantidad de registros que queres barrer
            DataTable dt = new DataTable();
            dt = dataSet.Tables[table];

            List<T> registrosEncontrados = new List<T>();

            foreach (DataRow dr in dt.Rows) //cada registro lo asigna a la lista y luego la devolvemos (respuesta generica para cualquier tipo de registro... clientes, autos, choferes, etc)
            {
                T entity = BuilderEntityFromDataRow(dr);
                registrosEncontrados.Add(entity);
            }
            return registrosEncontrados;
        }

        public abstract T BuilderEntityFromDataRow(DataRow dr);

        public abstract String tableName();

        protected String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda, String operador)
        {
            String queryCondition = "";
            String queryResult = "Select * from " + tableName();

            List<string> keyList = new List<string>(parametrosDeBusqueda.Keys);

            foreach (String key in keyList)
            {
                //---Esto que se agrega es nuevo, si falla algo es por esto------
                if (key == "entreFechas") //para la facturacion
                {
                    String[] fechas = parametrosDeBusqueda[key].Split('&');
                    String fechaInicio = fechas[0];
                    String fechaFinal = fechas[1];
                    queryCondition += "viaje_fecha_inicio >= " + "'" + fechaInicio + "'" + " and viaje_fecha_fin <= " + "'" + fechaFinal + "'" + " " + operador + " "; //Esto es una ultra negrada, ya que solo se usa para los viajes, en caso de usarse para otras entidades. Hacerlo bien

                }
                else if (key == "fecha_viaje_para_rendicion") { //para la rendicion
                    String fechaRendicion = parametrosDeBusqueda[key];
                    queryCondition += "viaje_fecha_inicio <= " + "'" + fechaRendicion + "'" + " and viaje_fecha_fin >= " + "'" + fechaRendicion + "'" + " " + operador + " ";
                }
                else if (key.Contains("marca") || key.Contains("estado") || key.Contains("dni") || key.Contains("telefono")) //estos son solo los datos que se buscan por exacto. Si no es ninguno de estos, entonces buscamos por like ;)
                {
                    String value = parametrosDeBusqueda[key];
                    queryCondition += key + " = " + "'" + value + "'" + " " + operador + " "; //se podria hacer un mapa por cada repo para abstraerte del nombre de la tabla, pero mucha paja
                }
                else {
                    String value = parametrosDeBusqueda[key];
                    queryCondition += key + " like " + "'%" + value + "%'" + " " + operador + " ";
                }
                //---------------------------------------------------------------
            }

            if (queryCondition != "")
            {
                queryCondition = queryCondition.Substring(0, queryCondition.Length - (operador.Length + 2));
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }

        public List<T> buscar(Dictionary<String, String> parametrosDeBusqueda, String operador = "and")
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda, operador);
            return SearchManager(query, tableName(), 0, 100);
        }

        public T getUltimoRegistro(String idColumn) {
            String querySearch = "Select top 1 * from " + tableName() + " order by " + idColumn + " desc";
            return SearchManager(querySearch, tableName(), 0, 6).First();
        }
    }
}
