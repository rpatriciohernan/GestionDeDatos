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
            
            Turno turno = new Turno(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToString(dr[3]), Convert.ToInt16(dr[4]), Convert.ToInt16(dr[5]), dr[6].ToString());
            return turno;
        }
        #endregion

        public void guardar(Turno turno)
        {
            SqlDataReader dr = queryManager("Insert into overhead.turnos " + "values(" + turno.GetValues() + ")");
            dr.Close();
        }

        public override String tableName() { return "overhead.turnos"; }

        public List<Turno> buscarTurnosSuperpuestos(Turno turno) {
            String query = "Select * from " + tableName() + " where turno_hora_inicio <= " + "'" + turno.HoraFin + "'" + " and " + "turno_hora_fin >= " + "'" + turno.HoraInicio + "'";
            return SearchManager(query, tableName(), 0, 6);
        }

        public void Modificar(Turno turno) {
           SqlDataReader dr = queryManager("UPDATE  " + tableName() + " SET turno_descripcion =" + "'" + turno.Descripcion + "'" + ", "
                + "turno_estado =" + "'" + turno.Estado + "'" + ", "
                + "turno_hora_inicio =" + "'" + turno.HoraInicio + "'" + ", "
                + "turno_hora_fin =" + "'" + turno.HoraFin + "'" + ", "
                + "turno_valor_km =" + "'" + turno.ValorKilometro + "'" + ", "
                + "turno_precio_base =" + "'" + turno.PrecioBase + "'" + ", "
                + " WHERE id_turno =" + Convert.ToString(turno.IdTurno));
            dr.Close();
        }

    }
}