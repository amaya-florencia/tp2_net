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
                //this.dgvUsuarios.DataSource = new UsuarioLogic().GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al listar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            UsuarioAlta formUsuario = new UsuarioAlta();
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count == 1)
            {
                //Obtengo el ID de la fila seleccionada
                int idUsuario = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                //Instancio formulario en modo MODIFICACION
                UsuarioAlta formUsuario = new UsuarioAlta(idUsuario, ApplicationForm.ModoForm.Modificacion);             
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int idUsuario = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioAlta formUsuario = new UsuarioAlta(idUsuario, ApplicationForm.ModoForm.Baja);
             formUsuario.ShowDialog();
             this.Listar();
        }
    }
}
