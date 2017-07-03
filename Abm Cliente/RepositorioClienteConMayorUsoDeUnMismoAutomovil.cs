using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.BuilderObjectViews;

namespace UberFrba.Abm_Cliente
{
    class RepositorioClienteConMayorUsoDeUnMismoAutomovil : Repositorio<ClienteConMayorUsoDeUnAutomovilView>
    {
        #region declaracion singleton
        private static RepositorioClienteConMayorUsoDeUnMismoAutomovil instance;

        private RepositorioClienteConMayorUsoDeUnMismoAutomovil() { }

        public static RepositorioClienteConMayorUsoDeUnMismoAutomovil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioClienteConMayorUsoDeUnMismoAutomovil();
                }
                return instance;
            }
        }
        #endregion


        #region builder del objeto cliente
        public override ClienteConMayorUsoDeUnAutomovilView BuilderEntityFromDataRow(DataRow dr)
        {  
            ClienteConMayorUsoDeUnAutomovilView clienteConMayorUsoDeUnAutomovilView = new ClienteConMayorUsoDeUnAutomovilView(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), Convert.ToInt16(dr[4]));
            return clienteConMayorUsoDeUnAutomovilView;
        }
        #endregion 

        public override String tableName() { return "overhead.clientes_con_mayor_uso_de_un_mismo_automovil"; }
    }
}

