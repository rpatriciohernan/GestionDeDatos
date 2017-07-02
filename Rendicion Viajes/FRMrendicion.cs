﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;
using UberFrba.BuilderObjectViews;
using UberFrba.Registro_Viajes;

namespace UberFrba.Rendicion_Viajes
{
    public partial class FRMrendicion : Form
    {
        private List<Chofer> choferes;
        private List<Turno> turnos;
        private Rendicion rendicion;

        public FRMrendicion()
        {
            InitializeComponent();
        }

        private void FRMrendicion_Load(object sender, EventArgs e)
        {
            Dictionary<String, String> searchAll = new Dictionary<string, string>();

            choferes = Chofer.buscar(searchAll);
            turnos = Turno.buscar(searchAll);

            //---Atributos que mostramos en los combos---
            choferes.ForEach(chofer => CMBchofer.Items.Add(chofer.Nombre + ", " + chofer.Apellido));
            turnos.ForEach(turno => CMBturno.Items.Add(turno.Descripcion));
        }

        private void BTNgenerar_Click(object sender, EventArgs e)
        {
            //validar que este todo bien seleccionado
            Dictionary<String, String> parametrosDeBusqueda = new Dictionary<string, string>();

            Int64 idChofer = getIdChoferSeleccionado();
            DateTime fecha = Convert.ToDateTime(DTEfecha.Text);
            Int64 idTurno = getIdTurno();

            parametrosDeBusqueda.Add("id_chofer", idChofer.ToString());
            parametrosDeBusqueda.Add("fecha", fecha.ToString()); //hacer logica para comparar con las fechas de los viajes
            parametrosDeBusqueda.Add("id_turno", idTurno.ToString());

            rendicion = Rendicion.calcularRendicion(parametrosDeBusqueda);
            mostrarAtributos();
        }

        private Int64 getIdChoferSeleccionado()
        {//si hay 2 choferes con mismo nombre y apellido no funciona -> habria que hacerlo por posicion del combo, mostrando en el combo el nombre, apellido y dni ;)!!
            return choferes.Find(chofer => chofer.Nombre + ", " + chofer.Apellido == CMBchofer.Text).Dni;
        }

        private Int64 getIdTurno() {
            return turnos.Find(turno => turno.Descripcion == CMBturno.Text).IdTurno;
        }

        private void mostrarAtributos()
        {
            TXTimporteTotal.Text = rendicion.Importe.ToString();
            TXTkilometros.Text = rendicion.Kilometros.ToString();
            TXTprecioBase.Text = rendicion.PrecioBase.ToString();
            TXTvalorKm.Text = rendicion.ValorKilometro.ToString();
            mostrarViajes();
        }

        private void mostrarViajes()
        {
            List<Viaje> viajes = rendicion.Viajes;
            List<ViajeView> viajesViews = viajes.Select(viaje => BuilderObjectView.Instance.createViajeViewFromViaje(viaje)).ToList(); //dados los viajes normales, creamos los viajesViews que son mas copados de vista al usuario. Al usuario no le interesa ver ids y demas
            BindingSource bs = new BindingSource(viajesViews, "");
            dataGridView1.DataSource = bs;
        }

        private void BTNcargar_Click(object sender, EventArgs e)
        {
            rendicion.guardate(); //-> chekea que no exista otra rendicion con misma fecha, turno y para el mismo chofer, si pasa estas validaciones se guarda
        }

    }
}
