using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    class RepositorioFacturacion : Repositorio<Facturacion>
    {

        #region declaracion singleton
        private static RepositorioFacturacion instance;

        private RepositorioFacturacion() { }

        public static RepositorioFacturacion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioFacturacion();
                }
                return instance;
            }
        }
        #endregion

        public List<Facturacion> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            String query = obtenerCondicionesDeBusqueda(parametrosDeBusqueda);
            List<Facturacion> facturacionesEncontradas = SearchManager(query, "overhead.facturaciones", 0, 6);
            return facturacionesEncontradas;
        }

        public void Guardar(Facturacion facturacion)
        {
            SqlDataReader dr = queryManager("Insert into overhead.facturaciones " + "values(" + facturacion.GetValues() + ")");
            dr.Close();
        }

        #region builder del objeto Facturacion
        public override Facturacion BuilderEntityFromDataRow(DataRow dr)
        {
            Facturacion facturacion = new Facturacion(Convert.ToInt16(dr[0]), Convert.ToDateTime(dr[1]), Convert.ToDateTime(dr[2]), Convert.ToInt16(dr[4]));
            return facturacion;
        }
        #endregion

        private String obtenerCondicionesDeBusqueda(Dictionary<String, String> parametrosDeBusqueda) //Tip: le agregamos el and al final siempre y a lo ultimo de todo se lo sacamos
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
