using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;


namespace UberFrba.Abm_Chofer
{
    class RepositorioChofer : Repositorio<Chofer>
    {
       #region declaracion singleton
        private static RepositorioChofer instance;

        private RepositorioChofer() { }

        public static RepositorioChofer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioChofer();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto cliente
        public override Chofer BuilderEntityFromDataRow(DataRow dr)
        {
            Chofer chofer = new Chofer(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), Convert.ToInt16(dr[4]), Convert.ToInt16(dr[5]), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), Convert.ToDateTime(dr[10]), dr[11].ToString());
            return chofer;
        }
        #endregion


        public List<Chofer> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Chofer> choferesEncontrados = SearchManager(query, "Choferes", 0, 6);
            return choferesEncontrados;
        }

        public void guardar(Chofer chofer)
        {
            SqlDataReader dr = queryManager("Insert into overhead.choferes " + "values(" + chofer.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda)
        {
            String queryCondition = "";
            String queryResult = "Select * from overhead.choferes";
            if (parametrosDeBusqueda.ContainsKey("nombre"))
            {
                String nombre = parametrosDeBusqueda["nombre"];
                queryCondition = "nombre = " + "'" + nombre + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("apellido"))
            {
                String apellido = parametrosDeBusqueda["apellido"];
                // queryCondition += "and apellido = " + apellido;
                queryCondition = "apellido = " + "'" + apellido + "'";
            }


            if (parametrosDeBusqueda.ContainsKey("estado"))
            {
                String estado = parametrosDeBusqueda["apellido"];
                // queryCondition += "and apellido = " + apellido;
                queryCondition = "estado = " + "'" + estado + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("dni"))
            {
                String dni = parametrosDeBusqueda["dni"];
                // queryCondition += "and dni = " + dni;
                queryCondition = "dni = " + "'" + dni + "'";
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
