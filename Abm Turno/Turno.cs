using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    class Turno
    {
        #region atributos

        private Int16 idTurno;
        private String descripcion;
        private String estado;
        private TimeSpan horaInicio; 
        private TimeSpan horaFin; 
        private double valorKilometro;
        private double precioBase;
        private static RepositorioTurno repositorioTurno = RepositorioTurno.Instance;

        #endregion


        #region getters y setters
        public Int16 IdTurno
        {
            get { return idTurno; }
        }
        public string Descripcion
        {
            get { return descripcion; }
        }
        public TimeSpan HoraInicio
        {
            get { return horaInicio; }
        }
        public TimeSpan HoraFin
        {
            get { return horaFin; }
        }
        public double ValorKilometro
        {
            get { return valorKilometro; }
        }
        public double PrecioBase
        {
            get { return precioBase; }
        }
        public string Estado
        {
            get { return estado; }
        }
        #endregion

        #region constructor
        public Turno(Int16 idTurno, String descripcion, TimeSpan horaInicio, TimeSpan horaFin, double valorKilometro, double precioBase, String estado)
        {
            this.idTurno = idTurno;
            this.descripcion = descripcion;
            this.estado = estado;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.valorKilometro = valorKilometro;
            this.precioBase = precioBase;
        }
        #endregion  
        
        #region constructor
        public Turno(String descripcion, TimeSpan horaInicio, TimeSpan horaFin, double valorKilometro, double precioBase, String estado)
        {
            this.descripcion = descripcion;
            this.estado = estado;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.valorKilometro = valorKilometro;
            this.precioBase = precioBase;
        }
        #endregion  
  
        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Turno> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioTurno.buscar(parametrosDeBusqueda);
        }

        public static Turno find(Dictionary<String, String> parametrosDeBusqueda)
        {
            return buscar(parametrosDeBusqueda).First();
        }

        //metodos de instancia
        public void guardate()
        {
            List<Turno> turnosSuperpuestos = repositorioTurno.buscarTurnosSuperpuestos(this);

            if (turnosSuperpuestos.Count > 0)
            {
                MessageBox.Show("La franja horaria seleccionada se superpone con la de otro turno, por favor elija otra");
            } else {
                repositorioTurno.guardar(this);
                MessageBox.Show("El turno se guardo correctamente");
            }
        }

        public void modificate() {
            List<Turno> turnosSuperpuestos = repositorioTurno.buscarTurnosSuperpuestos(this);

            if (turnosSuperpuestos.Count > 0)
            {
                MessageBox.Show("La franja horaria seleccionada se superpone con la de otro turno, por favor elija otra");
            }
            else
            {
                repositorioTurno.Modificar(this);
            }
        }

        public void eliminate()
        {
            this.estado = "Inactivo";
            repositorioTurno.Modificar(this);
        }

        public String GetValues()
        {
            return "'" + this.descripcion + "'" + ',' + "'" + Convert.ToString(this.horaInicio) + "'" + ',' + "'" +
                Convert.ToString(this.horaFin) + "'" + ',' + this.valorKilometro + ',' + 
                Convert.ToString(this.precioBase) + ',' + "'" + this.estado + "'";
        }
    }
}
