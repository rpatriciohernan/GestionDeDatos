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
        public FRMTurno()
        {
            InitializeComponent();
            CMBestado.Items.Add("Activo");
            CMBestado.Items.Add("InActivo");
        }

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Turno crearTurno() {
            return new Turno(TXTdescripcion.Text, CMBestado.Text, horaInicio, horaFin, Convert.ToDouble(TXTvalorKilometro.Text), Convert.ToDouble(TXTprecioBase.Text));
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {

            horaInicio = Convert.ToDateTime(DTEhoraInicio.Text).TimeOfDay;
            horaFin = Convert.ToDateTime(DTEhoraFin.Text).TimeOfDay;

            if (horaFin < horaInicio)
            {
                MessageBox.Show("El turno debe estar contemplado dentro de un mismo dia");
            } else {
                Turno turno = crearTurno();
                turno.guardate();
            }
        }

        private void FRMTurno_Load(object sender, EventArgs e)
        {

        }
    }
}
