using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    class Conexion
    {

        private static SqlConnection cn;

        private static Conexion instance;

        private Conexion() { }

        public static Conexion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Conexion();
                }
                return instance;
            }
        }

        public static SqlConnection getConnection() {
            return cn;
        }
        

        public static void startConexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=localhost" + @"\" + "SQLSERVER2012;Initial Catalog=GD1C2017;User ID=gd;Password=gd2017");
                cn.Open();

                String asd = "asdads";

                Console.Out.WriteLine( "'" + asd + "'");
                Console.Out.WriteLine(asd);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }
        }
    }
}

