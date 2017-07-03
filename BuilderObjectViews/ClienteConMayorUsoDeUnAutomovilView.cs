using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.BuilderObjectViews
{
    class ClienteConMayorUsoDeUnAutomovilView
    {
        private String nombre;
        private String apellido;
        private Int64 dni;
        private String patenteAuto;
        private Int16 vecesDeUso;

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
        public String PatenteAuto
        {
            get { return patenteAuto; }
        }
        public Int16 VecesDeUso
        {
            get { return vecesDeUso; }
        }


        public ClienteConMayorUsoDeUnAutomovilView(String nombre, String apellido, Int64 dni, String patenteAuto, Int16 vecesDeUso)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.patenteAuto = patenteAuto;
            this.vecesDeUso = vecesDeUso;
        }
    }
}
