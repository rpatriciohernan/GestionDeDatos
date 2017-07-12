using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class FRMTurno : Form
    {
        private double horaInicio;
        private double horaFin;

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

        public void obtenerValores(Int16 idTurno, String descripcion, double horaInicio, double horaFin, double valorKilometro, double precioBase, String estado)
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

            horaInicio = Convert.ToDouble(DTEhoraInicio.Text);
            horaFin = Convert.ToDouble(DTEhoraFin.Text);

            
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
            //asociacion de controlador de tipo de datos
            this.TXTprecioBase.KeyPress += TXTprecioBase_KeyPress;
            this.TXTvalorKilometro.KeyPress += TXTvalorKilometro_KeyPress;
            if (!formularioPrecargado) { BTNeliminar.Visible = false; CMBestado.Text = "Activo"; };
            if (formularioPrecargado) {
                formularioPrecargado = true;
                this.TXTdescripcion.Text = descripcion;
                this.CMBestado.Text = estado;
                this.DTEhoraInicio.Text = Convert.ToDateTime("2015-02-02 00:00:00.000").AddHours(horaInicio).ToString(); //new DateTime().AddHours(horaInicio).ToString();
                this.DTEhoraFin.Text = Convert.ToDateTime("2015-02-02 00:00:00.000").AddHours(horaFin).ToString();
                this.TXTvalorKilometro.Text = valorKilometro.ToString().Replace(',', '.');
                this.TXTprecioBase.Text = precioBase.ToString().Replace(',', '.');
            
            }

            DTEhoraInicio.Format = DateTimePickerFormat.Custom;
            DTEhoraInicio.CustomFormat = "HH"; // Only use hours 
            DTEhoraInicio.ShowUpDown = true;

            DTEhoraFin.Format = DateTimePickerFormat.Custom;
            DTEhoraFin.CustomFormat = "HH"; // Only use hours 
            DTEhoraFin.ShowUpDown = true;
        }

        private void TXTvalorKilometro_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTprecioBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTvalorKilometro_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar.ToString() != cc.NumberFormat.NumberDecimalSeparator)
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TXTprecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar.ToString() != cc.NumberFormat.NumberDecimalSeparator)
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
