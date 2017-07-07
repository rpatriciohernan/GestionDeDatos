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
    class RepositorioFuncionalidadAsignada : Repositorio<FuncionalidadAsignada>
    {
      #region declaracion singleton
        private static RepositorioFuncionalidadAsignada instance;

        private RepositorioFuncionalidadAsignada() { }

        public static RepositorioFuncionalidadAsignada Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioFuncionalidadAsignada();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto
        public override FuncionalidadAsignada BuilderEntityFromDataRow(DataRow dr)
        {
            FuncionalidadAsignada funcionalidadAsignada = new FuncionalidadAsignada(Convert.ToInt16(dr[0]), Convert.ToInt16(dr[1]));
            return funcionalidadAsignada;
        }
        #endregion

        public override String tableName() { return "overhead.funcionalidades_asignadas"; }

        public void guardar(FuncionalidadAsignada funcionalidadAsignada)
        {
            SqlDataReader dr = queryManager("Insert into overhead.funcionalidades_asignadas " + "values(" + funcionalidadAsignada.GetValues() + ")");
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO","Infomacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void eliminar(FuncionalidadAsignada funcionalidadAsignada)
        {
            SqlDataReader dr = queryManager("DELETE FROM overhead.funcionalidades_asignadas WHERE id_rol = " + Convert.ToString(funcionalidadAsignada.IdRol) + " AND " + "id_funcionalidad =" + Convert.ToString(funcionalidadAsignada.IdFuncionalidad));
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO","Infomacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
