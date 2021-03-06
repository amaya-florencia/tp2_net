﻿using System;
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
using Util;
namespace UI.Desktop
{
    public partial class PersonaABM : Form
    {

        Enumeradores.TiposPersonas tipoPersona;

        public PersonaABM(Enumeradores.TiposPersonas tipoPersona)
        {
            this.tipoPersona = tipoPersona;
            InitializeComponent();
        }
        public void Listar(Enumeradores.TiposPersonas tipoPersona)
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
        private void PersonaABM_Load_1(object sender, EventArgs e)
        {
            this.Listar(this.tipoPersona);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaAlta formPersona = new PersonaAlta(this.tipoPersona);
            formPersona.ShowDialog();
            this.Listar(this.tipoPersona);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                //Obtengo el ID de la fila seleccionada
                int idPersona = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

                //Instancio formulario en modo MODIFICACION
                PersonaAlta formPersona = new PersonaAlta(idPersona, ApplicationForm.ModoForm.Modificacion, this.tipoPersona);

                formPersona.ShowDialog();
                this.Listar(this.tipoPersona);
            }
            else
            {
                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {

                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

                PersonaAlta formPersona = new PersonaAlta(ID, ApplicationForm.ModoForm.Baja, this.tipoPersona);
                formPersona.ShowDialog();

                this.Listar(this.tipoPersona);

            }

            else
            {

                MessageBox.Show("Advertencia", "Primero seleccione una fila de la grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dgvPersonas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            this.dgvPersonas.AutoGenerateColumns = false;
        }
    }
}