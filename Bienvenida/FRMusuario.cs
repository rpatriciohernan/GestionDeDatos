using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Bienvenida
{
    public partial class FRMusuario : Form
    {
        String username;
        String password;
        Int64 dni;
        Int16 loginFallidos;
        String estado;
        Boolean formularioPrecargado = false;

        public FRMusuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FRMrolesAsignados formularioRoles = new FRMrolesAsignados();
            formularioRoles.recibirDatosUsuario(username);
            formularioRoles.Show();
        }

        public void recibirDatosUsuario(String username, String password, Int64 dni, Int16 loginFallidos, String estado) {
            this.username = username;
            this.TXTuserName.Enabled = false;
            this.password = password;
            this.dni = dni;
            this.loginFallidos = loginFallidos;
            this.estado = estado;
            formularioPrecargado = true;
        }

        private void FRMusuario_Load(object sender, EventArgs e)
        {
            CMBestado.Items.Add("Activo");
            CMBestado.Items.Add("Inactivo");
            if (formularioPrecargado) {
                TXTdni.Text = Convert.ToString(dni);
                TXTpassword.Text = password;
                TXTuserName.Text = username;
                CMBestado.Text = estado;
                TXTloginFallidos.Text = Convert.ToString(loginFallidos);
            }
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (this.estado != CMBestado.Text & CMBestado.Text == "Activo") { loginFallidos = 0; }
            if (this.password != TXTpassword.Text) { password = RepositorioUsuario.Instance.Encrypt(TXTpassword.Text); }
            Usuario nuevoUsuario = new Usuario(TXTuserName.Text, password, loginFallidos, Convert.ToInt64(TXTdni.Text), CMBestado.Text);
            if (formularioPrecargado) {nuevoUsuario.modificate();}else{nuevoUsuario.guardate();}
            this.Close();
        }
    }
}
