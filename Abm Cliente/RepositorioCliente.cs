using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Abm_Cliente
{
    class RepositorioCliente : Repositorio<Cliente>
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
        public override Cliente BuilderEntityFromDataRow(DataRow dr)
        {
            Cliente cliente = new Cliente(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]));
            return cliente;
        }
        #endregion


       /* public Cliente buscarASDFSF(Int64 dni) //esto en realidad va a ser un mapa o un obj con varias propiedades del cliente
        {
            SqlDataReader dr = queryManager("Select * from Clientes where dni=" + Convert.ToString(dni));
            //--Hacemos lectura y cerramos dataRead, ver como generalizar esto---
            dr.Read();
            Cliente cliente = BuilderClientFromDataReader(dr);
            dr.Close();
            //--------------------------------------------------------------------
            return cliente;
        }*/

        public List<Cliente> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Cliente> clientesEncontrados = SearchManager(query, "Clientes", 0, 6);
            return clientesEncontrados;
        }

        public void Guardar(Cliente cliente)
        {
            SqlDataReader dr = queryManager("Insert into Clientes " + "values(" + cliente.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda) {
            String queryCondition = "";
            String queryResult = "Select * from Clientes";
            if (parametrosDeBusqueda.ContainsKey("nombre")) {
                String nombre = parametrosDeBusqueda["nombre"];
                queryCondition = "nombre = " + "'" + nombre + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("apellido"))
            {
                String apellido = parametrosDeBusqueda["apellido"];
               // queryCondition += "and apellido = " + apellido;
                queryCondition = "apellido = " + "'" + apellido + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("dni"))
            {
                String dni = parametrosDeBusqueda["dni"];
               // queryCondition += "and dni = " + dni;
                queryCondition = "dni = " + "'" + dni + "'";
            }

            if (queryCondition != "") {
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }

    }
}


