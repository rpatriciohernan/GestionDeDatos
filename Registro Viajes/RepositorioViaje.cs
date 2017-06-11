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

        public List<Viaje> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Viaje> clientesEncontrados = SearchManager(query, "overhead.clientes", 0, 6);
            return clientesEncontrados;
        }

        public void Guardar(Viaje viaje)
        {
            SqlDataReader dr = queryManager("Insert into overhead.viajes " + "values(" + viaje.GetValues() + ")");
            dr.Close();
        }

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda)
        {
            String queryCondition = "";
            String queryResult = "Select * from Clientes";
            if (parametrosDeBusqueda.ContainsKey("nombre"))
            {
                String nombre = parametrosDeBusqueda["nombre"];
                queryCondition = "nombre = " + "'" + nombre + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("apellido"))
            {
                String apellido = parametrosDeBusqueda["apellido"];
                // queryCondition += "and apellido = " + apellido;
                queryCondition = "apellido = " + "'" + apellido + "'";
            }

            if (parametrosDeBusqueda.ContainsKey("dni"))
            {
                String dni = parametrosDeBusqueda["dni"];
                // queryCondition += "and dni = " + dni;
                queryCondition = "dni = " + "'" + dni + "'";
            }

            if (queryCondition != "")
            {
                queryResult += " where " + queryCondition;
            }
            Console.WriteLine("leete el queryResult: " + queryResult);
            return queryResult;
        }
    }
}
