using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class RepositorioClienteConMayorConsumo : Repositorio<Cliente>
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
        public override Cliente BuilderEntityFromDataRow(DataRow dr)
        {
            Cliente cliente = new Cliente(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt16(dr[6]), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString());
            return cliente;
        }
        #endregion

        public override String tableName() { return "overhead.clientes_con_mayor_consumo"; }
    }
}
