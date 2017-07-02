using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Bienvenida
{
    class RepositorioUsuario : Repositorio<Usuario>
    {
         #region declaracion singleton
        private static RepositorioUsuario instance;

        private RepositorioUsuario() { }

        public static RepositorioUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioUsuario();
                }
                return instance;
            }
        }
        #endregion


        #region builder del objeto
        public override Usuario BuilderEntityFromDataRow(DataRow dr)
        {
            Usuario usuario = new Usuario(dr[0].ToString(), dr[1].ToString(), Convert.ToInt16(dr[2]), Convert.ToInt64(dr[3]), dr[4].ToString());
            return usuario;
        }
        #endregion

        public override String tableName() { return "overhead.usuarios"; }

        public string Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public void Guardar(Usuario usuario)
        {
            SqlDataReader dr = queryManager("Insert into overhead.usuarios " + "values(" + usuario.GetValues() + ")");
            dr.Close();
        }

        public void Modificar(Usuario usuario)
        {
            SqlDataReader dr = queryManager("UPDATE overhead.usuarios SET usu_password =" + "'" + usuario.Password.ToString() + "'" + ", " + "usu_login_fallidos =" + "'" + usuario.LoginFallidos.ToString() + "'" + ", " + "usu_dni =" + "'" + usuario.Dni.ToString() + "'" + ", " + "usu_estado =" + "'" + usuario.Estado.ToString() + "'" + " WHERE username =" + "'" + Convert.ToString(usuario.Username) + "'");
            dr.Close();
        }
    }
}
