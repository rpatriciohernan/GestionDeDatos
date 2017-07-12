using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Rendicion rendicion = new Rendicion(Convert.ToInt16(dr[0]), Convert.ToInt64(dr[1]), Convert.ToInt16(dr[2]), Convert.ToDateTime(dr[3]), Convert.ToInt16(dr[4]));
            return rendicion;
        }
        #endregion


        public override String tableName() { return "overhead.rendiciones"; }

        public void Guardar(Rendicion rendicion)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("id_chofer", rendicion.IdChofer.ToString());
            parametrosDeBusqueda.Add("rendicion_fecha", rendicion.Fecha.ToString()); //esta fecha tiene que ser la del viaje
            parametrosDeBusqueda.Add("id_turno", rendicion.IdTurno.ToString());

            List<Rendicion> rendiciones = buscar(parametrosDeBusqueda);

            if (rendiciones.Count > 0) {
                MessageBox.Show("Ya Se hizo una rendicion para este chofer en el mismo dia y turno seleccionado","ATENCION!");
            } else {
                SqlDataReader dr = queryManager("Insert into overhead.rendiciones " + "values(" + rendicion.GetValues() + ")");
                dr.Close();
                MessageBox.Show("OPERACION REALIZADA CON EXITO","Infomacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
