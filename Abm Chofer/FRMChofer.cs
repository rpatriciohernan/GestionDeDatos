using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class FRMChofer : Form
    {
        public FRMChofer(String dni)
        {
            InitializeComponent();
            TXTdni.Text = dni;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FRMChofer_Load(object sender, EventArgs e)
        {

        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            //  LimpiarErrores();

            Chofer chofer = crearChofer();
            List<ErrorDeCampo> errores = chofer.validarCampos();

            if (errores.Count > 0)
            {
                // mostrarErrores(errores);
            }
            else
            {
                chofer.guardate();
            }
        }

        private Chofer crearChofer()
        {

            String nombre = TXTnombre.Text;
            String apellido = TXTapellido.Text;
            Int64 dni = Convert.ToInt64(TXTdni.Text);
            String mail = TXTmail.Text;
            String telefono = TXTtelefono.Text;
            String domicilio = TXTdomicilio.Text;
            //Int16 numero = Convert.ToInt16(TXTnumero.Text);
            //String depto = TXTdepto.Text;
            String localidad = TXTlocalidad.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(DTEfechaNacimiento.Text);

            return new Chofer(TXTnombre.Text, TXTapellido.Text, Convert.ToInt64(TXTdni.Text), TXTdomicilio.Text, 
                TXTlocalidad.Text, TXTtelefono.Text,  TXTmail.Text, Convert.ToDateTime(DTEfechaNacimiento.Text), "Activo");
        }

        /*
         private String nombre;
         private String apellido;
         private Int64 dni;
         private String domicilio;
         private String localidad;
         private String telefono;
         private String mail;
         private DateTime fechaNacimiento;
         private String estado;
         */
    }
}
