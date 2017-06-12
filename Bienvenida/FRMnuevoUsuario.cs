using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;

namespace UberFrba.Bienvenida
{
    public partial class FRMnuevoUsuario : Form
    {
        public FRMnuevoUsuario()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BTNSoyChofer_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMChofer formularioChofer = new FRMChofer(TXTdni.Text);

            // Show form
            formularioChofer.Show();           
        }

        public string SHA256Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }


        private void BTNSoyCliente_Click(object sender, EventArgs e)
        {
            // Create a new instance of the form
            FRMCliente formularioCliente = new FRMCliente(TXTdni.Text);

            // Show form
            formularioCliente.Show();  
        }

        private void BTNactivar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
