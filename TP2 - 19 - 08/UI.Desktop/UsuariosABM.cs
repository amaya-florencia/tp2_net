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
    public partial class UsuariosABM : Form
    {
        public UsuariosABM()
        {
            InitializeComponent();
        }

        /* private void Form1_Load(object sender, EventArgs e)
         {

         }*/
        public void Listar()
        {
            
            UsuarioLogic ul = new UsuarioLogic();
            try 
            { 
                this.dgvUsuarios.DataSource = ul.GetAll(); 
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error2","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
             

        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ///AlumnoAlta formUsuario = new AlumnoAlta(ApplicationForm.ModoForm.Alta);
            AlumnoAlta formUsuario = new AlumnoAlta();
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            AlumnoAlta formUsuario = new AlumnoAlta(id, ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
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
