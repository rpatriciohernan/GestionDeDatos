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

        #region builder del objeto chofer
        public override Chofer BuilderEntityFromDataRow(DataRow dr)
        {
            Chofer chofer = new Chofer(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]), dr[8].ToString());
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

        public void Modificar(Chofer chofer) {
            SqlDataReader dr = queryManager("UPDATE " + tableName() + " SET chofer_nombre =" + "'" + chofer.Nombre + "'" + ", "
                + "chofer_apellido =" + "'" + chofer.Apellido + "'" + ", "
                + "chofer_domicilio =" + "'" + chofer.Domicilio + "'" + ", "
                + "chofer_telefono =" + "'" + chofer.Telefono + "'" + ", "
                + "chofer_mail =" + "'" + chofer.Mail + "'" + ", "
                + "chofer_fecha_nacimiento =" + "'" + chofer.FechaNacimiento + "'" + ", "
                + "chofer_estado =" + "'" + chofer.Estado + "'" + " WHERE chofer_dni =" + Convert.ToString(chofer.Dni));
            dr.Close();
        }
    }
}
