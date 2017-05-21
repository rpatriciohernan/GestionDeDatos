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
        private String motivo;

        public ErrorDeCampo(String nombre, String motivo) {
            this.nombreCampo = nombre;
            this.motivo = motivo;
        }

        public String NombreCampo
        {
            get { return nombreCampo; }
        }

        public String Motivo
        {
            get { return motivo; }
        }
    }
}
