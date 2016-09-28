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
    public partial class PlanAlta : ApplicationForm
    {
        public PlanAlta()
        {
            InitializeComponent();
        }
        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }
        public PlanAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public PlanAlta(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic planLogic = new PlanLogic();
            try
            {
                this.PlanActual = planLogic.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        EspecialidadLogic esp = new EspecialidadLogic();
        private void PlanAlta_Load(object sender, EventArgs e)
        {
            cmbEspecialidad.DataSource = esp.GetAll();
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminacion del usuario" + this.PlanActual.Descripcion + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.OK)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                Plan plan = new Plan();
                this.PlanActual = plan;
            }
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;

                PlanActual.IdEspecialidad = this.cmbEspecialidad.SelectedIndex + 1;
                 
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            PlanLogic planLogic = new PlanLogic();
            if ((this.Modo == ApplicationForm.ModoForm.Alta) || (this.Modo == ApplicationForm.ModoForm.Modificacion))
            {
                try
                {
                    this.MapearADatos();                 
                    planLogic.Save(PlanActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    planLogic.Delete(PlanActual.ID);
                    this.Close();
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
