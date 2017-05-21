using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class ErrorDeCampo
    {
        private String nombreCampo;
        private String sugerencia;

        public ErrorDeCampo(String nombre, String motivo) {
            this.nombreCampo = nombre;
            this.sugerencia = motivo;
        }

        public String NombreCampo
        {
            get { return nombreCampo; }
        }

        public String Sugerencia
        {
            get { return sugerencia; }
        }


       /* public static enum Sugerencia
        {
            Vacio,
            Incorrecto
        };*/

       /* public static enum Nombre
        {
            Nombre,
            Apellido,
            Dni,
            Mail,
            Telefono,
            Direccion,
            CodigoPostal,
        };*/
    }
}
