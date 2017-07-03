using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.BuilderObjectViews
{
    class ClienteConMayorConsumoView
    {
        private String nombre;
        private String apellido;
        private Int64 dni;
        private double consumo;

        public string Nombre
        {
            get { return nombre; }
        }
        public string Apellido
        {
            get { return apellido; }
        }
        public Int64 Dni
        {
            get { return dni; }
        }
        public double Consumo
        {
            get { return consumo; }
        }


        public ClienteConMayorConsumoView(String nombre, String apellido, Int64 dni, double consumo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.consumo = consumo;
        }
    }
}
