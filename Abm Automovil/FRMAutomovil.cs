using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;

namespace UberFrba.Abm_Automovil
{
    public partial class FRMAutomovil : Form
    {

        private List<Marca> marcas;
        private List<Turno> turnos;
        private List<Chofer> choferes;
        String patente;
        Int16 idmarca;
        Int16 idmodelo;
        Int16 idturno;
        String estado;
        Int64 idChofer;
        Boolean formularioPrecargado = false;

        public FRMAutomovil()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            FRMMarcaVehiculo formularioMarcas = new FRMMarcaVehiculo();

            // Show the settings form
            formularioMarcas.Show();
        }

        private Boolean ValidarCamposMandatorios()
        {
            Boolean validado = true;

            if (String.IsNullOrEmpty(this.TXTpatente.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBmarca.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.TXTmodelo.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBturno.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBChofer.Text)) { validado = false; }
            if (String.IsNullOrEmpty(this.CMBestado.Text)) { validado = false; }

            return validado;

        }

        private void MensajeError()
        {
            MessageBox.Show("ACCION RECHAZADA: No ha completado los campos mandatorios identificados con asterisco (*)", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNguardar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposMandatorios())
            {
                if (formularioPrecargado) { this.crearAutomovil().modificate(); } else { this.crearAutomovil().guardate(); BTNeliminar.Visible = true; }
            }
            else
            {
                this.MensajeError();
            };
           
        }

        
        private Automovil crearAutomovil() {

            //obtenemos el id de los datos de los combos, ya que provienen de otras tablas
            Int16 idMarca = marcas.Find(marca => marca.Nombre == CMBmarca.Text).IdMarca;
            
            //Int16 idTurno = -1;
            Int16 idTurno = turnos.Find(turno => turno.Descripcion == CMBturno.Text).IdTurno;

            Int64 idChofer = choferes.Find(chofer => chofer.Nombre == CMBChofer.Text).Dni;


            return new Automovil(TXTpatente.Text, idMarca,
                Convert.ToInt16(TXTmodelo.Text), idTurno,
                idChofer, CMBestado.Text);
        }
      //  Convert.ToString(row.Cells[0].Value), Convert.ToInt16(row.Cells[1].Value),Convert.ToInt16(row.Cells[2].Value
        public void obtenerDatos( String patente, Int16 idmarca, Int16 idmodelo, Int16 idturno, Int64 idChofer, String estado) {
            this.patente = patente;
            this.idmarca = idmarca;
            this.idmodelo = idmodelo;
            this.idturno = idturno;
            this.estado = estado;
            this.idChofer = idChofer;
            this.formularioPrecargado = true;
        }

        private void FRMAutomovil_Load(object sender, EventArgs e)
        {
            this.CMBestado.Items.Add("Activo");
            this.CMBestado.Items.Add("Inactivo");
            if (!formularioPrecargado) { this.CMBestado.Text = "Activo"; BTNeliminar.Visible = false; };

            Dictionary<String, String> searchAll = new Dictionary<string, string>();

            marcas = Marca.buscar(searchAll);
            turnos = Turno.buscar(searchAll);
            choferes = Chofer.buscar(searchAll);

            //---Atributos que mostramos en los combos---
            marcas.ForEach(marca => CMBmarca.Items.Add(marca.Nombre));

            turnos.ForEach(turno => CMBturno.Items.Add(turno.Descripcion));

            choferes.ForEach(chofer => CMBChofer.Items.Add(chofer.Nombre));

            if (formularioPrecargado) {
                this.TXTpatente.Text = patente;
                this.CMBmarca.Text = marcas.Find(marca => marca.IdMarca == idmarca).Nombre;
                this.TXTmodelo.Text = idmodelo.ToString();
                this.CMBturno.Text = turnos.Find(turno => turno.IdTurno == idturno).Descripcion;
                this.CMBestado.Text = estado;
                this.CMBChofer.Text = choferes.Find(chofer => chofer.Dni == idChofer).Nombre;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
