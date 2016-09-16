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
    public partial class EspecialidadesAMB : Form
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        public EspecialidadesAMB()
        {
            InitializeComponent();           
            this.Listar();
        }
        public EspecialidadesAMB(Usuario u) : this() {
            UsuarioActual = u;
        }
        private void Especialidades_Load(object sender, EventArgs e)
        {
            VerificarABMC();
            this.Listar();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadAlta formEspec = new EspecialidadAlta();
            formEspec.ShowDialog();
            this.Listar();
        }
        private void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                this.dgvEspecialidades.DataSource = el.GetAll();
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
                if (mu.Modulo.Descripcion == "Especialidades")
                {
                    this.dgvEspecialidades.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count == 1)
            {
               
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;               
                
                EspecialidadAlta formEspecialidad = new EspecialidadAlta(ID, ApplicationForm.ModoForm.Modificacion);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count == 1)
            {                
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;                
                EspecialidadAlta formEspecialidad = new EspecialidadAlta(ID, ApplicationForm.ModoForm.Baja);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
