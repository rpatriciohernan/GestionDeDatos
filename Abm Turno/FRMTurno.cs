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
        public FRMTurno()
        {
            InitializeComponent();
            CMBestado.Items.Add("Activo");
            CMBestado.Items.Add("Inactivo");
        }

        Boolean formularioPrecargado = false;
        String descripcion;
        String estado;
        DateTime horaInicio;
        DateTime horaFin;
        Int16 valorKilometro;
        Int16 precioBase;

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void obtenerValores(String descripcion, String estado, DateTime horaInicio, DateTime horaFin, Int16 valorKilometro, Int16 precioBase) {
            formularioPrecargado = true;
            this.descripcion = descripcion;
            this.estado= estado;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.valorKilometro = valorKilometro;
            this.precioBase = precioBase;            
        
        }

        private Turno crearTurno() {
            String horaInicio = String.Format("{0:t}", Convert.ToDateTime(DTEhoraInicio.Text));
            String horaFin = String.Format("{0:t}", Convert.ToDateTime(DTEhoraFin.Text));
            return new Turno(TXTdescripcion.Text, CMBestado.Text, horaInicio, horaFin, Convert.ToInt16(TXTvalorKilometro.Text), Convert.ToInt16(TXTprecioBase.Text));
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
                    this.crearTurno().guardate();
                    this.BTNeliminar.Enabled = true; };
                if (formularioPrecargado) { this.crearTurno().modificate(); };
            }
            else
            {
                this.MensajeError();
            };
        }

        private void FRMTurno_Load(object sender, EventArgs e)
        {
            if (!formularioPrecargado) { BTNeliminar.Visible = false; CMBestado.Text = "Activo"; };
            if (formularioPrecargado) {
                formularioPrecargado = true;
                this.TXTdescripcion.Text = descripcion;
                this.CMBestado.Text = estado;
                this.DTEhoraInicio.Value = horaInicio;
                this.DTEhoraFin.Value = horaFin;
                this.TXTvalorKilometro.Text = valorKilometro.ToString();
                this.TXTprecioBase.Text = precioBase.ToString();       
            
            }
        }
    }
}
