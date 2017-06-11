using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Bienvenida
{
    class RepositorioUsuario : Repositorio<Usuario>
    {
         #region declaracion singleton
        private static RepositorioUsuario instance;

        private RepositorioUsuario() { }

        public static RepositorioUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioUsuario();
                }
                return instance;
            }
        }
        #endregion


        #region builder del objeto
        public override Usuario BuilderEntityFromDataRow(DataRow dr)
        {
            Usuario usuario = new Usuario(dr[0].ToString(), dr[1].ToString(), Convert.ToInt16(dr[2]), Convert.ToInt16(dr[3]), dr[4].ToString());
            return usuario;
        }
        #endregion

        public override String tableName() { return "overhead.usuarios"; }

        public void Guardar(Usuario usuario)
        {
            SqlDataReader dr = queryManager("Insert into overhead.usuarios " + "values(" + usuario.GetValues() + ")");
            dr.Close();
        }
    }
}
