using System; //ok
using System.Configuration; //ok
using System.Collections.Generic; //ok
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class Utils
    {
        public static DateTime appDate = Convert.ToDateTime(ConfigurationManager.AppSettings["AppDate"]);
        public static DateTime minDate = new DateTime(1890, 1, 1);

        public static String connectionString = ConfigurationManager.ConnectionStrings["dataBase"].ConnectionString;
    }
}
