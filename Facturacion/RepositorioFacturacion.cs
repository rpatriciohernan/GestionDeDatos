using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    class RepositorioFacturacion : Repositorio<Facturacion>
    {

        #region declaracion singleton
        private static RepositorioFacturacion instance;

        private RepositorioFacturacion() { }

        public static RepositorioFacturacion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioFacturacion();
                }
                return instance;
            }
        }
        #endregion


        public override String tableName() { return "overhead.facturaciones"; }

        public Facturacion Guardar(Facturacion facturacion)
        {
            SqlDataReader dr = queryManager("Insert into overhead.facturaciones " + "values(" + facturacion.GetValues() + ")");
            dr.Close();

            MessageBox.Show("OPERACION REALIZADA CON EXITO");

            Facturacion facturacionStored = getUltimoRegistro("id_factura");
            return facturacionStored;
        }

        #region builder del objeto Facturacion
        public override Facturacion BuilderEntityFromDataRow(DataRow dr)
        {
            Facturacion facturacion = new Facturacion(Convert.ToInt16(dr[0]), Convert.ToDateTime(dr[1]), Convert.ToInt64(dr[2]), Convert.ToDateTime(dr[3]), Convert.ToDateTime(dr[4]), Convert.ToDouble(dr[5]));
            return facturacion;
        }
        #endregion
    }
}
