using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;


namespace UberFrba.Abm_Chofer
{
    class RepositorioChofer : Repositorio<Chofer>
    {
       #region declaracion singleton
        private static RepositorioChofer instance;

        private RepositorioChofer() { }

        public static RepositorioChofer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioChofer();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto cliente
        public override Chofer BuilderEntityFromDataRow(DataRow dr)
        {
            Chofer chofer = new Chofer(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), Convert.ToInt16(dr[4]), Convert.ToInt16(dr[5]), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), Convert.ToDateTime(dr[10]), dr[11].ToString());
            return chofer;
        }
        #endregion


        public override String tableName() { return "overhead.choferes"; }

        public void guardar(Chofer chofer)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("chofer_dni", chofer.Dni.ToString());

            List<Chofer> choferes = buscar(parametrosDeBusqueda);

            if (choferes.Count > 0) {
                MessageBox.Show("Ya Existe un chofer con el mismo DNI");
            } else {
                SqlDataReader dr = queryManager("Insert into overhead.choferes " + "values(" + chofer.GetValues() + ")");
                dr.Close();
                MessageBox.Show("El chofer se guardo correctamente");
            }

            
        }

    }
}
