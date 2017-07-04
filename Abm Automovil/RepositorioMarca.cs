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
    class RepositorioMarca : Repositorio<Marca>
    {
        #region declaracion singleton
        private static RepositorioMarca instance;

        private RepositorioMarca() { }

        public static RepositorioMarca Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioMarca();
                }
                return instance;
            }
        }
        
        #endregion

       #region builder del objeto cliente
        public override Marca BuilderEntityFromDataRow(DataRow dr)
        {
            Marca marca = new Marca(Convert.ToInt16(dr[0]) , dr[1].ToString());
            return marca;
        }
        #endregion

        public override String tableName() { return "overhead.marcas"; }

        public void Guardar(Marca marca)
        {
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();
            parametrosDeBusqueda.Add("marca_nombre", marca.Nombre.ToString());

            List<Marca> marcas = buscar(parametrosDeBusqueda);

            if (marcas.Count > 0)
            {
                MessageBox.Show("Ya Existe esta marca");
            } else {
                SqlDataReader dr = queryManager("Insert into overhead.marcas " + "values(" + marca.GetValues() + ")");
                dr.Close();
                MessageBox.Show("OPERACION REALIZADA CON EXITO");
            }
        }

        public void Eliminar(Marca marca)
        {
            SqlDataReader dr = queryManager("DELETE FROM overhead.marcas WHERE id_marca = " + marca.IdMarca);
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }

        public void Modificar(Marca marca)
        {
            SqlDataReader dr = queryManager("UPDATE  " + tableName() + " SET marca_nombre =" + "'" + marca.Nombre + "'" + " WHERE id_marca = " + marca.IdMarca);
            dr.Close();
            MessageBox.Show("OPERACION REALIZADA CON EXITO");
        }

    }

    }
