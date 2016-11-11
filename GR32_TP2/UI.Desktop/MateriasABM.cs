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
    public partial class MateriasABM : Form
    {
        public MateriasABM()
        {
            InitializeComponent();
            Listar();
        }

        private void tsmNuevo_Click(object sender, EventArgs e)
        {
            MateriasAlta formMateria = new MateriasAlta(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
        }

        private void tsmEditar_Click(object sender, EventArgs e)
        {

            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                //Obtengo el ID de la fila seleccionada
                int idMateria = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                //Instancio formulario en modo MODIFICACION
                MateriasAlta formMateria = new MateriasAlta(idMateria, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int idMateria = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasAlta formMateria = new MateriasAlta(idMateria, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Listar()
        {

            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.dgvMaterias.DataSource = ml.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al listar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
