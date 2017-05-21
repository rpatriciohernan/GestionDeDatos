using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class Persona
    {
        private String nombre;
        private String apellido;

        public Persona(String nombre, String apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Nombre
        {

            get { return nombre; }

        }

        public string Apellido
        {

            get { return apellido; }

        }
    }
}
