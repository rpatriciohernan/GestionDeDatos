using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Rendicion_Viajes
{
    class RepositorioRendicion : Repositorio<Rendicion>
    {
        #region declaracion singleton
        private static RepositorioRendicion instance;

        private RepositorioRendicion() { }

        public static RepositorioRendicion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioRendicion();
                }
                return instance;
            }
        }
        #endregion   
    
        #region builder del objeto 
        public override Rendicion BuilderEntityFromDataRow(DataRow dr)
        {
            Rendicion rendicion = new Rendicion(Convert.ToInt16(dr[0]), Convert.ToInt16(dr[1]), Convert.ToInt16(dr[2]), Convert.ToDateTime(dr[3]), Convert.ToInt16(dr[4]));
            return rendicion;
        }
        #endregion


        public override String tableName() { return "overhead.rendiciones"; }

        public void Guardar(Rendicion rendicion)
        {
            SqlDataReader dr = queryManager("Insert into overhead.rendiciones " + "values(" + rendicion.GetValues() + ")");
            dr.Close();
        }
    }
}
