using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Funcionalidad
{
    class RepositorioFuncionalidad : Repositorio<Funcionalidad>
    {
      #region declaracion singleton
        private static RepositorioFuncionalidad instance;

        private RepositorioFuncionalidad() { }

        public static RepositorioFuncionalidad Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioFuncionalidad();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto
        public override Funcionalidad BuilderEntityFromDataRow(DataRow dr)
        {
            Funcionalidad funcionalidad = new Funcionalidad(Convert.ToInt16(dr[0]), dr[1].ToString());
            return funcionalidad;
        }
        #endregion

        public override String tableName() { return "overhead.funcionalidades"; }

        public void guardar(Funcionalidad funcionalidad)
        {
            SqlDataReader dr = queryManager("Insert into overhead.funcionalidades " + "values(" + funcionalidad.GetValues() + ")");
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }

        public void eliminar(Funcionalidad funcionalidad)
        {
            SqlDataReader dr = queryManager("DELETE FROM overhead.funcionalidades WHERE funcionalidad_nombre = " + "'" + Convert.ToString(funcionalidad.Nombre) + "'");
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }

    }
}
