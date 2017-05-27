using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Abm_Cliente
{
    class Repositorio
    {
        protected SqlDataReader queryManager(String query)
        {
            SqlCommand cmd = new SqlCommand(query, Conexion.getConnection());
            return cmd.ExecuteReader();
        }

        protected DataTable buscarConPaginado(String query, String table, int numeroDePagina, int tamanioDePagina)
        {
            int pageNumber = numeroDePagina * tamanioDePagina; //el principio de todo es cero (0)
            string orderSQL = query;

            SqlDataAdapter adapter = new SqlDataAdapter(orderSQL, Conexion.getConnection());

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, pageNumber, tamanioDePagina, table); //pageNumber seria el indice en donde se empieza a barrer, tamanioDePagina cantidad de registros que queres barrer
            DataTable dt = new DataTable();
            dt = dataSet.Tables[table];
            return dt;
        }
    }
}
