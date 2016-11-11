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
    public partial class PlanABM : Form
    {
        public PlanABM()
        {
            InitializeComponent();
        }
        public void Listar()
        {

            PlanLogic pl = new PlanLogic();
            try
            {
                this.dgvPlan.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al listar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void tsmAgregar_Click_1(object sender, EventArgs e)
        {
            PlanAlta formPlan = new PlanAlta(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }
        private void dgvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPlan.AutoGenerateColumns = false;
        }
        private void PlanABM_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void tsmEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlan.SelectedRows.Count == 1)
            {                
                int idPlan = ((Business.Entities.Plan)this.dgvPlan.SelectedRows[0].DataBoundItem).ID;                
                PlanAlta formPlan = new PlanAlta(idPlan, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void tsmEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvPlan.SelectedRows.Count == 1)
            {
                int idPlan = ((Business.Entities.Plan)this.dgvPlan.SelectedRows[0].DataBoundItem).ID;
                PlanAlta formPlan = new PlanAlta(idPlan, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
