using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Chofer
{
    class RepositorioChoferConViajeMasLargo : Repositorio<Chofer>
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
        public override Chofer BuilderEntityFromDataRow(DataRow dr)
        {
            Chofer chofer = new Chofer(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]), dr[8].ToString());
            return chofer;
        }
        #endregion

        public override String tableName() { return "overhead.choferes_con_viaje_mas_largo"; }

    }
}

