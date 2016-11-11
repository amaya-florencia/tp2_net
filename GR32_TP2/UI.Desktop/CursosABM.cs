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
    public partial class CursosABM : ApplicationForm
    {
        public CursosABM()
        {
            InitializeComponent();
        }
        public void Listar()
        {

            CursosLogic cl = new CursosLogic();
            try
            {
                this.dgvCursos.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al listar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region
        private void tsmNuevo_Click(object sender, EventArgs e)
        {
            CursosAlta formCurso = new CursosAlta();
            formCurso.ShowDialog();
            
        }

        private void tsmEditar_Click(object sender, EventArgs e)
        {

            if (this.dgvCursos.SelectedRows.Count == 1)
            {

                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosAlta formCurso = new CursosAlta(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosAlta formCurso = new CursosAlta(ID, ApplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void CursosABM_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvCursos.AutoGenerateColumns = false;
        }


        #endregion


    }
}
