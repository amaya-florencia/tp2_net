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

namespace UI.Desktop.Reportes
{
    public partial class MateriasPorPlan : Form
    {
        public MateriasPorPlan()
        {
            InitializeComponent();
            CargarComboEspecialidades();
        }

        private void CargarComboEspecialidades()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                cmbEspecialidad.DataSource = el.GetAll();
                cmbEspecialidad.DisplayMember = "Descripcion";
                cmbEspecialidad.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MateriasPorPlan_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsMateriasPlanes1.PlanesMaterias' Puede moverla o quitarla según sea necesario.
            this.planesMateriasTableAdapter.Fill(this.dsMateriasPlanes1.PlanesMaterias);

            this.rvMateriasPlanes.RefreshReport();
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboEspecialidad();
        }

        private void CargarComboEspecialidad()
        {
            try
            {
                int idEspecialidad = (int)this.cmbEspecialidad.SelectedValue;
                cmbPlan.DataSource = new PlanLogic().GetAll(idEspecialidad);
                cmbPlan.DisplayMember = "Descripcion";
                cmbPlan.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Listar()
        {
            
            
        }             

        private void button1_Click(object sender, EventArgs e)
        {
            int idEspecialidad = (int)this.cmbEspecialidad.SelectedValue;
            int idPlan = (int)this.cmbPlan.SelectedValue;
            this.planesMateriasTableAdapter.FillBy(this.dsMateriasPlanes1.PlanesMaterias, idEspecialidad, idPlan);
            this.rvMateriasPlanes.RefreshReport();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
            this.planesMateriasTableAdapter.Fill(this.dsMateriasPlanes1.PlanesMaterias);
     
        }
    }
}
