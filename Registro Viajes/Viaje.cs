﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Turno;

namespace UberFrba.Registro_Viajes
{
    class Viaje
    {
        private Int64 id;
        private Int64 idChofer;
        private String idAutomovil;
        private Int64 idTurno;
        private Double cantidadKilometros;
        private DateTime inicio;
        private DateTime fin;
        private String idFactura; //vamos a hacer las facturas calculables, asi que setteamos este id una vez que se haya creado la factura
        private Int64 idCliente;

        private double monto;
        private static RepositorioViaje repositorioViaje = RepositorioViaje.Instance;


        #region getters y setters
        public Int64 Id
        {
            get { return id; }
        }
        public void setIdFactura(String idFactura)
        {
            this.idFactura = idFactura;
        }
        public Int64 IdChofer
        {
            get { return idChofer; }
        }
        public String IdAutomovil
        {
            get { return idAutomovil; }
        }
        public Int64 IdTurno
        {
            get { return idTurno; }
        }
        public Double CantidadKilometros
        {
            get { return cantidadKilometros; }
        }
        public DateTime Inicio
        {
            get { return inicio; }
        }
        public DateTime Fin
        {
            get { return fin; }
        }
        public String IdFactura
        {
            get { return idFactura; }
        }
        public Int64 IdCliente
        {
            get { return idCliente; }
        }
        public double Monto
        {
            get { return monto; }
        }
        #endregion

        #region constructores
        public Viaje(Int64 id, Int64 idChofer, String idAutomovil, Int64 idTurno, Double cantidadKilometros, DateTime inicio, DateTime fin, Int64 idCliente, String idFactura)
        {
            this.id = id;
            this.idChofer = idChofer;
            this.idAutomovil = idAutomovil;
            this.idTurno = idTurno;
            this.cantidadKilometros = cantidadKilometros;
            this.inicio = inicio;
            this.fin = fin;
            this.idFactura = idFactura;
            this.idCliente = idCliente;
        }

        public Viaje(Int64 idChofer, String idAutomovil, Int64 idTurno, Double cantidadKilometros, DateTime inicio, DateTime fin, Int64 idCliente, String idFactura)
        {
            this.idChofer = idChofer;
            this.idAutomovil = idAutomovil;
            this.idTurno = idTurno;
            this.cantidadKilometros = cantidadKilometros;
            this.inicio = inicio;
            this.fin = fin;
            this.idFactura = idFactura;
            this.idCliente = idCliente;
        }
        #endregion constructor


        //metodos de clase (no se necesita tener una instancia para usarlos)
        public static List<Viaje> buscar(Dictionary<String, String> parametrosDeBusqueda)
        {
            return repositorioViaje.buscar(parametrosDeBusqueda);
        }

        //metodos de instancia
        public void guardate()
        {
            List<Viaje> viajes = repositorioViaje.buscarViajesSuperpuestos(this);
            if (viajes.Count > 0)
            {
                MessageBox.Show("La franja horaria seleccionada se superpone con la de otro viaje para el mismo cliente o chofer ya cargado, por favor verifique el inicio y fin del viaje");
            } else {
                repositorioViaje.Guardar(this);
            }
        }

        public void modificate()
        {
            List<Viaje> viajes = repositorioViaje.buscarViajesSuperpuestos(this);
            if (viajes.Count > 0)
            {
                MessageBox.Show("La franja horaria seleccionada se superpone con la de otro viaje ya cargado, por favor verifique el inicio y fin del viaje");
            }
            else
            {
                repositorioViaje.Modificar(this);
            }
        }

        public double calcularMonto() //le pegamos a la base por cada viaje, no es lo mas copado, pero por ahora lo dejamos asi :/
        { 
            //supongo que el monto es el precioBase del turno + (precioDelKilometro x cantKilometrosRecorridos)
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<String, String>();
            parametrosDeBusqueda.Add("id_turno", idTurno.ToString());

            Turno turno = Turno.find(parametrosDeBusqueda);

            double monto = turno.PrecioBase + turno.ValorKilometro * this.cantidadKilometros;
            this.monto = monto; //para que el viajeView tenga el monto
            return monto;
        }


        #region values
        public String GetValues()
        { 
            return "'" + this.idChofer + "'" + ',' + "'" + this.idAutomovil + "'" + ',' +
                "'" + this.idTurno + "'" + ',' + "'" + this.cantidadKilometros + "'" + ',' + "'" + this.inicio + "'" + ',' +
                "'" + this.fin + "'" + ',' + "'" + this.idCliente + "'" + ',' + "'" + this.idFactura + "'";
        #endregion
        }
    }
}
