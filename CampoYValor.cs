using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class CampoYValor
    {
        private String campo;
        private String valor;

        public CampoYValor(String campo, String valor) {
            this.campo = campo;
            this.valor = valor;
        }

        public String Campo
        {
            get { return campo; }
        }

        public String Valor
        {
            get { return valor; }
        }
    }
}
