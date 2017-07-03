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

        public override String tableName() { return "overhead.roles"; }

        public void Guardar(Rol rol)
        {
            SqlDataReader dr = queryManager("Insert into overhead.roles " + "values(" + rol.GetValues() + ")");
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }

        public void Modificar(Rol rol)
        {
            SqlDataReader dr = queryManager("UPDATE overhead.roles SET rol_nombre =" + "'" + rol.Nombre + "'" + ", " + "rol_estado =" + "'" + rol.Estado + "'" + " WHERE id_rol =" + Convert.ToString(rol.Id));
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }
    }
}
