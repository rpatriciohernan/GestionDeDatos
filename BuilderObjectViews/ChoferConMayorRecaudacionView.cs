using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.BuilderObjectViews
{
    class ChoferConMayorRecaudacionView
    {
        private String nombre;
        private String apellido;
        private Int64 dni;
        private double recaudacion;

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
        public double Recaudacion
        {
            get { return recaudacion; }
        }


        public ChoferConMayorRecaudacionView(String nombre, String apellido, Int64 dni, double recaudacion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.recaudacion = recaudacion;
        }
    }
}
