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
          //  LimpiarErrores();

            Cliente cliente = crearCliente();
            List<ErrorDeCampo> errores = cliente.validarCampos();

            if (errores.Count > 0)
            {
               // mostrarErrores(errores);
            }
            else
            {
                cliente.guardate();
            }
        }


        private void TXTdni_TextChanged(object sender, EventArgs e)
        {

        }

        private Cliente crearCliente() {

            String nombre = TXTnombre.Text;
            String apellido = TXTapellido.Text;
            Int64 dni = Convert.ToInt64(TXTdni.Text);
            String mail = TXTmail.Text;
            String telefono = TXTtelefono.Text;
            String domicilio = TXTdomicilio.Text;
            //Int16 numero = Convert.ToInt16(TXTnumero.Text);
            //String depto = TXTdepto.Text;
            Int16 cp = Convert.ToInt16(TXTcodigoPostal.Text);
            String localidad = TXTlocalidad.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(DTEfechaNacimiento.Text);




            return new Cliente(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTmail.Text,
                TXTtelefono.Text, TXTdomicilio.Text,Convert.ToInt16(TXTcodigoPostal.Text), TXTlocalidad.Text, Convert.ToDateTime(DTEfechaNacimiento.Text), "Activo");
        }

        private void DTEfechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
