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
    class RepositorioChoferConViajeMasLargo : Repositorio<ChoferConViajeMasLargoView>
    {
     #region declaracion singleton
        private static RepositorioChoferConViajeMasLargo instance;

        private RepositorioChoferConViajeMasLargo() { }

        public static RepositorioChoferConViajeMasLargo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioChoferConViajeMasLargo();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto chofer
        public override ChoferConViajeMasLargoView BuilderEntityFromDataRow(DataRow dr)
        {
            ChoferConViajeMasLargoView choferConViajeMasLargoView = new ChoferConViajeMasLargoView(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), Convert.ToDouble(dr[3]));
            return choferConViajeMasLargoView;
        }
        #endregion

        public override String tableName() { return "overhead.choferes_con_viaje_mas_largo"; }

    }
}

