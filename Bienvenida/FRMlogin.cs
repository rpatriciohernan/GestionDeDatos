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

namespace UberFrba.Bienvenida
{
    public partial class FRMlogin : Form
    {
        public FRMlogin()
        {
            InitializeComponent();
        }

        private Usuario usuario;

        private void BTNingresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CMBrolDeAcceso.Text)) { 
                MessageBox.Show("SELECCIONE UN ROL DE ACCESO", "ATENCION!"); }
            else {
            FRMBienvenida formularioBienvenida = new FRMBienvenida(this.TXTusername.Text.ToString(), this.CMBrolDeAcceso.Text.ToString());
            formularioBienvenida.Show();

            //Hide actual form (not closing cause it turns the app off)
            this.Hide();
            }
        }

        private void BTNnuevoUsuario_Click_1(object sender, EventArgs e)
        {
            FRMnuevoUsuario formularioNuevoUsuario = new FRMnuevoUsuario();
            formularioNuevoUsuario.Show();
        }

        private void HabilitarLogueo()
        {
            BTNingresar.Visible = true;
            CMBrolDeAcceso.Visible = true;
            LBLrol.Visible = true;
        }

        private void MostrarErrorLogueo()
        {
            LBLerrorLogueo.Visible = true;
        }

        private Boolean ValidarLogueo()
        {
            Dictionary<String, String> parametrosBusquedaUsuario = new Dictionary<String, String>();
            parametrosBusquedaUsuario.Add("usu_estado", "Activo");
            parametrosBusquedaUsuario.Add("username", this.TXTusername.Text);
            List<Usuario> usuariosEncontrados = Usuario.buscar(parametrosBusquedaUsuario);
            if (usuariosEncontrados.Count() > 0) { usuario = usuariosEncontrados.First(); };
            // colocar funcion HASH para transformar password
            String vecX = RepositorioUsuario.Instance.Encrypt(this.TXTpassword.Text);
            if ((usuariosEncontrados.Count() > 0) && (usuario.Password == vecX))
            {
                this.RellenarComboRoles(usuario);
                return true;
            }
            else
            {
                if (usuariosEncontrados.Count() > 0) { usuario.IncrementarLoguinfallido(); };
                return false;
            }
        }

        private void RellenarComboRoles(Usuario ingresante)
        {
            List<String> rolesAsignados = ingresante.RolesAsignados();
            rolesAsignados.ForEach(rol => CMBrolDeAcceso.Items.Add(rol));
        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.LBLerrorLogueo.Visible = false;
            
             if (this.ValidarLogueo())
             {
            this.HabilitarLogueo();
             }
             else
             {
                 this.MostrarErrorLogueo();
             }


        }

        private void BTNadmin_Click(object sender, EventArgs e)
        {

            FRMBienvenida formularioBienvenida = new FRMBienvenida(this.TXTusername.Text.ToString(), this.CMBrolDeAcceso.Text.ToString());
            formularioBienvenida.ActivarAdministrador();
            formularioBienvenida.Show();
        }
    }
}
