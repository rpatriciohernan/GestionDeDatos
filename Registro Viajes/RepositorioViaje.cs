using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Registro_Viajes
{
    class RepositorioViaje : Repositorio<Viaje>
    {

        #region declaracion singleton
        private static RepositorioViaje instance;

        private RepositorioViaje() { }

        public static RepositorioViaje Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioViaje();
                }
                return instance;
            }
        }
        #endregion

        #region builder del objeto viaje
        public override Viaje BuilderEntityFromDataRow(DataRow dr)
        {
            Viaje viaje = new Viaje(Convert.ToInt16(dr[0]), Convert.ToInt16(dr[1]), dr[2].ToString(), Convert.ToInt16(dr[3]), Convert.ToDouble(dr[4]), Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6]), Convert.ToInt16(dr[7]), Convert.ToInt16(dr[8]));
            return viaje;
        }
        #endregion


        public override String tableName() { return "overhead.viajes"; }

        public void Guardar(Viaje viaje)
        {
            SqlDataReader dr = queryManager("Insert into overhead.viajes " + "values(" + viaje.GetValues() + ")");
            dr.Close();
        }

        public void Modificar(Viaje viaje) {
            SqlDataReader dr = queryManager("UPDATE " +tableName()+ " SET id_chofer =" + "'" + viaje.IdChofer + "'" + ", " +
                    "id_automovil =" + "'" + viaje.IdAutomovil + "'" + ", " +
                    "id_turno =" + "'" + viaje.IdTurno + "'" + ", " +
                    "viaje_cant_km =" + "'" + viaje.CantidadKilometros + "'" + ", " +
                    "viaje_fecha_inicio =" + "'" + viaje.Inicio + "'" + ", " +
                    "viaje_fecha_fin =" + "'" + viaje.Fin + "'" + ", " +
                    "id_factura =" + "'" + viaje.IdFactura + "'" + ", " +
                    "id_cliente =" + "'" + viaje.IdCliente + "'"
                    + " WHERE id_viaje =" + Convert.ToString(viaje.Id));
            dr.Close();
        }


    }
}
