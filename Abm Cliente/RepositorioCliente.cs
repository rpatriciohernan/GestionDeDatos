using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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

        private Cliente BuilderClientFromDataRow(DataRow dr)
        {
            Cliente cliente = new Cliente(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]));
            return cliente;
        }


        public Cliente buscar(Int64 dni) //esto en realidad va a ser un mapa o un obj con varias propiedades del cliente
        {
            SqlDataReader dr = queryManager("Select * from Clientes where dni=" + Convert.ToString(dni));
            //--Hacemos lectura y cerramos dataRead, ver como generalizar esto---
            dr.Read();
            Cliente cliente = BuilderClientFromDataReader(dr);
            dr.Close();
            //--------------------------------------------------------------------
            return cliente;
        }

        //todo esto va a ser un solo metodo generico ;)
        public List<Cliente> buscarTodos() {
          /*  SqlDataReader dr = queryManager("Select * from Clientes");
            List<Cliente> clientesEncontrados = new List<Cliente>();

            while (dr.Read()) {
                Cliente cliente = BuilderClientFromDataReader(dr);
                clientesEncontrados.Add(cliente);
            }
            dr.Close();
            return clientesEncontrados;*/

            var dt = buscarConPaginado("Select * from Clientes","Clientes",0,6);

            List<Cliente> clientesEncontrados = new List<Cliente>();

            foreach (DataRow dr in dt.Rows)
            {
                Cliente cliente = BuilderClientFromDataRow(dr);
                Console.WriteLine("cliente encontradoooooooo!!!!: " + cliente.Nombre);
                clientesEncontrados.Add(cliente);
            }
            return clientesEncontrados;
            
        }

        /*
          List<MyClass> results = new List<MyClass>();

   while(dr.Read())
   {
       MyClass newItem = new MyClass();

       newItem.Id = dr.GetInt32(0);  
       newItem.TypeId = dr.GetInt32(1);  
       newItem.AllowedSMS = dr.GetBoolean(2);  
       newItem.TimeSpan = dr.GetString(3);
       newItem.Price = dr.GetDecimal(4);
       newItem.TypeName = dr.GetString(5);

       results.Add(newItem);
   }
}
         */

        public void Guardar(Cliente cliente) {
            SqlDataReader dr = queryManager("Insert into Clientes "+  "values(" + cliente.GetValues() + ")");
            dr.Close();
        }


    }
}
