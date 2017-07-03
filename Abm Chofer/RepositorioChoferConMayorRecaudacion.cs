using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;
using UberFrba.BuilderObjectViews;

namespace UberFrba.Abm_Chofer
{
    class RepositorioChoferConMayorRecaudacion : Repositorio<ChoferConMayorRecaudacionView>
    {
        #region declaracion singleton
        private static RepositorioChoferConMayorRecaudacion instance;

        private RepositorioChoferConMayorRecaudacion() { }

        public static RepositorioChoferConMayorRecaudacion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioChoferConMayorRecaudacion();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto chofer
        public override ChoferConMayorRecaudacionView BuilderEntityFromDataRow(DataRow dr)
        {
            ChoferConMayorRecaudacionView choferConMayorRecaudacionView = new ChoferConMayorRecaudacionView(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), Convert.ToDouble(dr[3]));
            return choferConMayorRecaudacionView;
        }
        #endregion


        public override String tableName() { return "overhead.choferes_con_mayor_recaudacion"; }
    }
}
