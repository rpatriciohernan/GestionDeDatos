using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class FRMTurno : Form
    {
        private TimeSpan horaInicio;
        private TimeSpan horaFin;

        private Boolean formularioPrecargado = false;
        private String descripcion;
        private String estado;
        private double valorKilometro;
        private double precioBase;
        private Int16 idTurno;

        public FRMTurno()
        {
            InitializeComponent();
            CMBestado.Items.Add("Activo");
            CMBestado.Items.Add("Inactivo");
        }

        

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void obtenerValores(Int16 idTurno, String descripcion, TimeSpan horaInicio, TimeSpan horaFin, double valorKilometro, double precioBase, String estado)
        {
            formularioPrecargado = true;
            this.descripcion = descripcion;
            this.estado= estado;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.valorKilometro = valorKilometro;
            this.precioBase = precioBase;
            this.idTurno = idTurno;
        }

        private Turno crearTurno() {
            return new Turno(idTurno, TXTdescripcion.Text, horaInicio, horaFin, Convert.ToDouble(TXTvalorKilometro.Text), Convert.ToDouble(TXTprecioBase.Text), CMBestado.Text);
        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTdescripcion.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.DTEhoraFin.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.DTEhoraFin.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTvalorKilometro.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTprecioBase.Text)) { validado = false; }

            return validado;

        }


        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                if (!formularioPrecargado) {
                    guardarTurno();
                    this.BTNeliminar.Enabled = true; };
                if (formularioPrecargado) { this.crearTurno().modificate(); };
                this.Close();
            }
            else
            {
                this.MensajeError();
            };
        }

        private void guardarTurno() {
            horaInicio = Convert.ToDateTime(DTEhoraInicio.Text).TimeOfDay;
            horaFin = Convert.ToDateTime(DTEhoraFin.Text).TimeOfDay;

            if (horaFin < horaInicio)
            {
                MessageBox.Show("El turno debe estar contemplado dentro de un mismo dia");
            }
            else
            {
                crearTurno().guardate();
            }
        }

        private void FRMTurno_Load(object sender, EventArgs e)
        {
            if (!formularioPrecargado) { BTNeliminar.Visible = false; CMBestado.Text = "Activo"; };
            if (formularioPrecargado) {
                formularioPrecargado = true;
                this.TXTdescripcion.Text = descripcion;
                this.CMBestado.Text = estado;
                this.DTEhoraInicio.Text = horaInicio.ToString();
                this.DTEhoraFin.Text = horaFin.ToString();
                this.TXTvalorKilometro.Text = valorKilometro.ToString();
                this.TXTprecioBase.Text = precioBase.ToString();       
            
            }
        }
    }
}
