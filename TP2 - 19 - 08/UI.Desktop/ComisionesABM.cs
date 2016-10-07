using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class ComisionesABM : Form
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        public ComisionesABM()
        {
            InitializeComponent();
            this.Listar();
        }
        public ComisionesABM(Usuario u) : this() {
            UsuarioActual = u;
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            VerificarABMC();
            this.Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionAlta formComi = new ComisionAlta();
            formComi.ShowDialog();
            this.Listar();
        }
        public void Listar()
        {
           ComisionLogic el = new ComisionLogic();
            try
            {
                this.dgvComisiones.DataSource = el.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void VerificarABMC()
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuario)
            {
                if (mu.Modulo.Descripcion == "Comisiones")
                {
                    this.dgvComisiones.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
         }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count == 1)
            {

                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;

                ComisionAlta formComision = new ComisionAlta (ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionAlta formComision = new ComisionAlta(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
