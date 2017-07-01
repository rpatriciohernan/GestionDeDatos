using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.BuilderObjectViews
{
    class ViajeView
    {
        
        private Double cantidadKilometros;
        private DateTime inicio;
        private DateTime fin;
        private double monto;

        
        public DateTime Inicio
        {
            get { return inicio; }
        }
        public DateTime Fin
        {
            get { return fin; }
        }
        public Double CantidadKilometros
        {
            get { return cantidadKilometros; }
        }
        public double Monto
        {
            get { return monto; }
        }
         
        public ViajeView(DateTime inicio, DateTime fin, Double cantidadKilometros, double monto)
        {
            this.inicio = inicio;
            this.fin = fin;
            this.cantidadKilometros = cantidadKilometros;
            this.monto = monto;
        }
    }
}
