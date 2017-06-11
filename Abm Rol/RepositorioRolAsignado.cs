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
    class RepositorioRolAsignado : Repositorio<RolAsignado>
    {
        #region declaracion singleton
        private static RepositorioRolAsignado instance;

        private RepositorioRolAsignado() { }

        public static RepositorioRolAsignado Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioRolAsignado();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto
        public override RolAsignado BuilderEntityFromDataRow(DataRow dr)
        {
            RolAsignado rolAsignado = new RolAsignado(dr[0].ToString(), Convert.ToInt16(dr[1]));
            return rolAsignado;
        }
        #endregion

        public override String tableName() { return "overhead.roles_asignados"; }

        public void Guardar(RolAsignado rolAsignado)
        {
            SqlDataReader dr = queryManager("Insert into overhead.roles_asignados " + "values(" + rolAsignado.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda)
        {
            String queryCondition = "";
            String queryResult = "Select * from overhead.roles_asignados";
            if (parametrosDeBusqueda.ContainsKey("username"))
            {
                String username = parametrosDeBusqueda["username"];
                queryCondition = "username = " + "'" + username + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("idRol"))
            {
                String idRol = parametrosDeBusqueda["idRol"];
                queryCondition = "idRol = " + "'" + idRol + "'";
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
