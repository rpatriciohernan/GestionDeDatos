using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.BuilderObjectViews
{
    class ChoferConViajeMasLargoView
    {
        private String nombre;
        private String apellido;
        private Int64 dni;
        private double kilometrosDeViaje;

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
        public double KilometrosDeViaje
        {
            get { return kilometrosDeViaje; }
        }

        public ChoferConViajeMasLargoView(String nombre, String apellido, Int64 dni, double kilometrosDeViaje)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.kilometrosDeViaje = kilometrosDeViaje;
        }
    }
}
