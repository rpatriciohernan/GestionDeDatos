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
            CMBestado.Items.Add("InActivo");
        }

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Turno crearTurno() {
            String horaInicio = String.Format("{0:t}", Convert.ToDateTime(DTEhoraInicio.Text));
            String horaFin = String.Format("{0:t}", Convert.ToDateTime(DTEhoraFin.Text));
            return new Turno(TXTdescripcion.Text, CMBestado.Text, horaInicio, horaFin, Convert.ToInt16(TXTvalorKilometro.Text), Convert.ToInt16(TXTprecioBase.Text));
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            //  LimpiarErrores();

            Turno turno = crearTurno();
            List<ErrorDeCampo> errores = turno.validarCampos();

            if (errores.Count > 0)
            {
                // mostrarErrores(errores);
            }
            else
            {
                turno.guardate();
            }
        }

        private void FRMTurno_Load(object sender, EventArgs e)
        {

        }
    }
}
