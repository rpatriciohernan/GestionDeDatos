using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    class Automovil
    {
        String patente;
        Int16 idMarca;
        Int16 idModelo;
        Int16 idTurno;
        Int64 choferDni;
        String estado;
        private static RepositorioAutomovil repositorioAutomovil = RepositorioAutomovil.Instance;

        #region getters y setters
        public string Patente
        {
            get { return patente; }
        }

        public Int16 IdMarca
        {
            get { return idMarca; }
        }
        public Int16 IdModelo
        {
            get { return idModelo; }
        }

        public Int16 IdTurno
        {
            get { return idTurno; }
        }
        public Int64 ChoferDni
        {
            get { return choferDni; }
        }

        public string Estado
        {
            get { return estado; }
        }
        #endregion

        #region constructor
        public Automovil(String patente, Int16 idMarca, Int16 idModelo, Int16 idTurno, Int64 choferDni, String estado) {
            this.patente = patente;
            this.idMarca = idMarca;
            this.idModelo = idModelo;
            this.idTurno = idTurno;
            this.choferDni = choferDni;
            this.estado = estado;
        }
        #endregion

        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Automovil> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioAutomovil.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            repositorioAutomovil.Guardar(this);
        }

        public void modificate()
        {
            repositorioAutomovil.Modificar(this);
        }

        public void eliminate()
        {
            this.estado = "Inactivo";
            repositorioAutomovil.Modificar(this);
        }

        #region values
        public String GetValues() { 
            return "'" + this.patente + "'" + ',' + "'" + this.idMarca + "'" + ',' + "'" + this.idModelo + "'" + ',' +
                "'" + this.idTurno + "'" + ',' + "'" + this.choferDni + "'" + ',' + "'" + this.estado + "'";
        }
        #endregion

    }
}
