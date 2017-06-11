using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class FRMCliente : Form
    {
        public FRMCliente( String dni)
        {
            InitializeComponent();
            TXTdni.Text = dni;
        }

        private void FRMCliente_Load(object sender, EventArgs e)
        {

        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {

        }

        private Cliente CrearCliente()
        {
            return new Cliente(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTmail.Text, TXTtelefono.Text,
            TXTcalle.Text, Convert.ToInt16(TXTnumero.Text), TXTpiso.Text, TXTdepto.Text, TXTlocalidad.Text, TXTcodigoPostal.Text, Convert.ToDateTime(DTEfechaNacimiento.Text));
        }
    }
}
