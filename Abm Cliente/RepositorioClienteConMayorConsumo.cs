using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.BuilderObjectViews;

namespace UberFrba.Abm_Cliente
{
    class RepositorioClienteConMayorConsumo : Repositorio<ClienteConMayorConsumoView>
    {
        #region declaracion singleton
        private static RepositorioClienteConMayorConsumo instance;

        private RepositorioClienteConMayorConsumo() { }

        public static RepositorioClienteConMayorConsumo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioClienteConMayorConsumo();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto cliente
        public override ClienteConMayorConsumoView BuilderEntityFromDataRow(DataRow dr)
        {
            ClienteConMayorConsumoView clienteConMayorConsumoView = new ClienteConMayorConsumoView(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), Convert.ToDouble(dr[3]));
            return clienteConMayorConsumoView;
        }
        #endregion

        public override String tableName() { return "overhead.clientes_con_mayor_consumo"; }
    }
}
