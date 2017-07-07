using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            MessageBox.Show("OPERACION REALIZADA CON EXITO","Infomacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Eliminar(RolAsignado rolAsignado)
        {
            SqlDataReader dr = queryManager("DELETE FROM overhead.roles_asignados WHERE username = " + "'" + Convert.ToString(rolAsignado.Username)+ "'" + " AND " + "id_rol =" + Convert.ToString(rolAsignado.IdRol));
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO","Infomacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
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
