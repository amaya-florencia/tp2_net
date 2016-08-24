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


namespace UI.Desktop
{
    public partial class EspecialidadesAMB : Form
    {
        public EspecialidadesAMB()
        {
            InitializeComponent();
        }
        private void Especialidades_Load(object sender, EventArgs e)
        {
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
    }
}
