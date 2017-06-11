using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Rol
{
    class RepositorioRol : Repositorio<Rol>
    {
        #region declaracion singleton
        private static RepositorioRol instance;

        private RepositorioRol() { }

        public static RepositorioRol Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioRol();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto rol
        public override Rol BuilderEntityFromDataRow(DataRow dr)
        {
            Rol rol = new Rol(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString());
            return rol;
        }
        #endregion

        public List<Rol> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Rol> rolesEncontrados = SearchManager(query, "overhead.roles", 0, 6);
            return rolesEncontrados;
        }

        public void Guardar(Rol rol)
        {
            SqlDataReader dr = queryManager("Insert into overhead.roles " + "values(" + rol.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda)
        {
            String queryCondition = "";
            String queryResult = "Select * from overhead.roles";
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
