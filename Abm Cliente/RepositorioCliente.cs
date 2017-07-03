using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    class RepositorioCliente : Repositorio<Cliente>
    {
        #region declaracion singleton
        private static RepositorioCliente instance;

        private RepositorioCliente() { }

        public static RepositorioCliente Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioCliente();
                }
                return instance;
            }
        }
        #endregion
              
        
       
        #region builder del objeto cliente
        public override Cliente BuilderEntityFromDataRow(DataRow dr)
        {
            Cliente cliente = new Cliente(dr[0].ToString(), dr[1].ToString(), Convert.ToInt64(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt16(dr[6]), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString());
            return cliente;
        }
        #endregion

        public override String tableName() { return "overhead.clientes"; }

        public void Guardar(Cliente cliente)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("cliente_dni", cliente.Dni.ToString());
            parametrosDeBusqueda.Add("cliente_telefono", cliente.Telefono.ToString());

            List<Cliente> clientes = buscar(parametrosDeBusqueda,"or");

            if (clientes.Count > 0)
            {
                MessageBox.Show("Ya Existe un cliente con el mismo DNI o el mismo TELEFONO");
            } else {
                SqlDataReader dr = queryManager("Insert into overhead.clientes " + "values(" + cliente.GetValues() + ")");
                dr.Close();
                MessageBox.Show("OPERACION REALIZADA CON EXITO");
            }
        }

        public void Modificar(Cliente cliente) {
            SqlDataReader dr = queryManager("UPDATE " + tableName() + " SET cliente_nombre =" + "'" + cliente.Nombre + "'" + ", "
                + "cliente_apellido =" + "'" + cliente.Apellido + "'" + ", "
                + "cliente_mail =" + "'" + cliente.Mail + "'" + ", "
                + "cliente_telefono =" + "'" + cliente.Telefono + "'" + ", "
                + "cliente_domicilio =" + "'" + cliente.Domicilio + "'" + ", "
                + "cliente_codigo_postal =" + "'" + cliente.CodigoPostal + "'" + ", "
                + "cliente_localidad =" + "'" + cliente.Localidad + "'" + ", "
                + "cliente_fecha_nacimiento =" + "'" + cliente.FechaNacimiento + "'" + ", "
                + "cliente_estado =" + "'" + cliente.Estado + "'" + " WHERE cliente_dni =" + Convert.ToString(cliente.Dni));
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }
    }
}


