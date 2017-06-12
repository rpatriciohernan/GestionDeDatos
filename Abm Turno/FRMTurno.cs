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
            CMBestado.Items.Add("Habilitado");
            CMBestado.Items.Add("Inhabilitado");
        }

        private void CMBestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Turno(String descripcion, String estado, DateTime horaInicio, DateTime horaFin, Int16 valorKilometro, Int16 precioBase)

        private Turno crearTurno() {
            return new Turno(TXTdescripcion.Text, CMBestado.Text, Convert.ToDateTime(DTEhoraInicio.Text), Convert.ToDateTime(DTEhoraFin.Text), Convert.ToInt16(TXTvalorKilometro.Text), Convert.ToInt16(TXTprecioBase.Text));
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
    }
}
