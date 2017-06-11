using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Turno
{
    class RepositorioTurno : Repositorio<Turno>
    {
        #region declaracion singleton
        private static RepositorioTurno instance;

        private RepositorioTurno() { }

        public static RepositorioTurno Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioTurno();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto
        public override Turno BuilderEntityFromDataRow(DataRow dr)
        {
            Turno turno = new Turno(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), Convert.ToDateTime(dr[4].ToString()), Convert.ToInt16(dr[5]), Convert.ToInt16(dr[6]));
            return turno;
        }
        #endregion

        public void guardar(Turno turno)
        {
            SqlDataReader dr = queryManager("Insert into overhead.turnos " + "values(" + turno.GetValues() + ")");
            dr.Close();
        }

        public override String tableName() { return "overhead.turnos"; }

    }
}
