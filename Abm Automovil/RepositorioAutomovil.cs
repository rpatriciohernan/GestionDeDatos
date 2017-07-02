using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;

namespace UberFrba.Abm_Automovil
{
    class RepositorioAutomovil : Repositorio<Automovil> 
    {

        #region declaracion singleton
        private static RepositorioAutomovil instance;

        private RepositorioAutomovil() { }

        public static RepositorioAutomovil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioAutomovil();
                }
                return instance;
            }
        }
        #endregion


        #region builder del objeto automovil
        public override Automovil BuilderEntityFromDataRow(DataRow dr)
        {
            Automovil automovil = new Automovil(dr[0].ToString(), Convert.ToInt16(dr[1]), Convert.ToInt16(dr[2]), Convert.ToInt16(dr[3]), Convert.ToInt64(dr[4]), dr[5].ToString());
            return automovil;
        }
        #endregion


        public override String tableName() { return "overhead.automoviles"; }

        public void Guardar(Automovil automovil)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("auto_patente", automovil.Patente.ToString());

            List<Automovil> autos = buscar(parametrosDeBusqueda);

            if (autos.Count > 0)
            {
                MessageBox.Show("Ya Existe un automovil con esta patente");
            } else {
                SqlDataReader dr = queryManager("Insert into overhead.automoviles " + "values(" + automovil.GetValues() + ")");
                dr.Close();
                MessageBox.Show("El automovil se guardo correctamente");
            }
        }

        public void Modificar(Automovil automovil) { 
            SqlDataReader dr = queryManager("UPDATE " + tableName() + " SET id_marca =" + "'" + Convert.ToString(automovil.IdMarca)+ "'" + ", "
                + "id_chofer =" + "'" + Convert.ToString(automovil.ChoferDni)+ "'" + ", "
                + "auto_modelo =" + "'" + Convert.ToString(automovil.IdModelo) + "'" + ", "
                + "auto_estado =" + "'" + automovil.Estado + "'" + ", "
                + "id_turno =" + "'" + Convert.ToString(automovil.IdTurno) + "'" + ", "
                + " WHERE auto_patente =" + Convert.ToString(automovil.Patente));
                dr.Close();
        }
    }
}
