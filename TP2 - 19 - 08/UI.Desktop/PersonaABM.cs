using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PersonaABM : Form
    {
        private Enum tipoPersona;

        public PersonaABM()
        {
            InitializeComponent();
        }

        public PersonaABM(Enum tipoPersona)
        {
            this.tipoPersona = tipoPersona;
        }

        public void Listar(Enum tipoPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.dgvPersonas.DataSource = pl.GetAll(tipoPersona);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al llenar la grilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PersonaABM_Load(object sender, EventArgs e)
        {
            this.Listar(this.tipoPersona);
        }

        private void tlPersonas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar(this.tipoPersona);
        }

        private void btnSsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaAlta formPersona = new PersonaAlta();
            formPersona.ShowDialog();
            this.Listar(this.tipoPersona);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                //Obtengo el ID de la fila seleccionada
                int idPersona = Int32.Parse(((DataRowView)this.dgvPersonas.SelectedRows[0].DataBoundItem)["id_usuario"].ToString());

                //Instancio formulario en modo MODIFICACION
                PersonaAlta formPersona = new PersonaAlta(idPersona, ApplicationForm.ModoForm.Modificacion);

                formPersona.ShowDialog();
                this.Listar(this.tipoPersona);
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            /* int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
             AlumnoAlta formUsuario = new AlumnoAlta(id, ApplicationForm.ModoForm.Baja);
             formUsuario.ShowDialog();
             this.Listar();*/
        }
    }
}
