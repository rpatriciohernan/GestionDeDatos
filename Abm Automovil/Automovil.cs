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
        private List<CampoYValor> camposObligatorios;
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
            //--cargar en esta lista, los campos obligatorios del cliente--
            this.camposObligatorios = new List<CampoYValor>();

            this.patente = patente;
            this.camposObligatorios.Add(new CampoYValor("Patente", this.patente));

            this.idMarca = idMarca;
            this.camposObligatorios.Add(new CampoYValor("Marca", this.idMarca.ToString()));

            this.idModelo = idModelo;
            this.camposObligatorios.Add(new CampoYValor("Modelo", this.idModelo.ToString()));

            this.idTurno = idTurno;
            this.camposObligatorios.Add(new CampoYValor("Turno", this.idTurno.ToString()));

            this.choferDni = choferDni;
            this.camposObligatorios.Add(new CampoYValor("Chofer", this.choferDni.ToString()));

            this.estado = estado;
            this.camposObligatorios.Add(new CampoYValor("Estado", this.estado));
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

        public List<ErrorDeCampo> validarCampos()
        { //controlar que el nombre del campo sea igual al que conoce el form pq sino no funciona
            //filter
            List<CampoYValor> camposObligatoriosVacios = camposObligatorios.Where(elem => (elem.Valor == null || elem.Valor == "")).ToList();
            //map
            List<ErrorDeCampo> errores = camposObligatoriosVacios.Select(error => new ErrorDeCampo(error.Campo, "falta completar")).ToList();
            return errores;
        }

        #region values
        public String GetValues() { //ojo al agregar nuevos atributo, volcarlos aca!!!
            return "'" + this.patente + "'" + ',' + "'" + this.idMarca + "'" + ',' + "'" + this.idModelo + "'" + ',' +
                "'" + this.idTurno + "'" + ',' + "'" + this.choferDni + "'" + ',' + "'" + this.estado + "'";
        }
        #endregion

    }
}
