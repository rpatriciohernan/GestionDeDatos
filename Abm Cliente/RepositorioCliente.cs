using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UberFrba.Abm_Cliente
{
    class RepositorioCliente : Repositorio
    {
        #region declaracion singleton
        private static RepositorioCliente instance;

        private RepositorioCliente() { }

        public static RepositorioCliente Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioCliente();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto cliente
        private Cliente BuilderClientFromDataReader(SqlDataReader dr)
        {
            Cliente cliente = new Cliente(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]));
            return cliente;
        }
        #endregion

        public Cliente buscar(Int64 dni)
        {
            SqlDataReader dr = queryManager("Select * from Clientes where dni=" + Convert.ToString(dni));
            //--Hacemos lectura y cerramos dataRead, ver como generalizar esto---
            dr.Read();
            Cliente cliente = BuilderClientFromDataReader(dr);
            dr.Close();
            //--------------------------------------------------------------------
            return cliente;
        }

        public void Guardar(Cliente cliente) {
            SqlDataReader dr = queryManager("Insert into Clientes "+  "values(" + cliente.GetValues() + ")");
        }


    }
}
