using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UberFrba.Abm_Cliente
{
    class Repositorio
    {
        protected SqlDataReader queryManager(String query)
        {
            SqlCommand cmd = new SqlCommand(query, Conexion.getConnection());
            return cmd.ExecuteReader();
        }
    }
}
