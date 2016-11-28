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
        public Plan PlanActual;
        EspecialidadLogic esp = new EspecialidadLogic();
        public PlanAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public PlanAlta()
        {
            InitializeComponent();
            try
            {
                CargarCombo();
            }
            catch (Exception e)
            {
                this.Notificar("Especialidades", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
       
        private void CargarCombo()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidad.DataSource = el.GetAll();
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "Id";
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
                PlanActual.IdEspecialidad = (int)this.cmbEspecialidad.SelectedValue;
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
        
        public override void MapearDeDatos()
        {

            this.txtIdPlan.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cmbEspecialidad.SelectedValue = this.PlanActual.IdEspecialidad;

            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Usuario";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.Text = "Baja de Usuario";
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.Text = "Consulta de Usuario";
                    btnAceptar.Text = "Aceptar";
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
                    planLogic.Save(this.PlanActual);
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
        public override bool Validar()
        {
            string mensaje = "";
            if (String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                mensaje += "Debe completar la descripcion del plan\n";
            }
            else if (this.txtDescripcion.Text.Length > 50)
            {
                mensaje += "La descripcion del plan puede tener como máximo 50 caracteres\n";
            }
            if (!(this.cmbEspecialidad.SelectedIndex > -1))
            {
                mensaje += "Debe seleccionar una especialidad en la lista desplegable";
            }
            if (mensaje.Length == 0)
            {
                return true;
            }
            else
            {
                this.Notificar("Advertencia", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void PlanAlta_Load(object sender, EventArgs e)
        {

        }
    }
}
