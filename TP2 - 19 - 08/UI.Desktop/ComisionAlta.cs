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
    public partial class ComisionAlta : ApplicationForm
    {
        public Comision ComisionActual;

        //PlanLogic plan = new PlanLogic(); (Dudo de esto)
        EspecialidadLogic esp = new EspecialidadLogic();
        public ComisionAlta()
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
        public ComisionAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionAlta(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic comisionLogic = new ComisionLogic();
            try
            {
                this.ComisionActual = comisionLogic.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                ComisionActual = new Comision();
            }
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = (int)this.cmbAnioEspecialidad.SelectedValue;
                ComisionActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            this.lblID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.cmbAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            switch (this.Modo)
            {

                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Comision";
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.txtDescripcion.ReadOnly = true;
                    this.Text = "Baja de Comision";
                    btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void GuardarCambios()
        {
            ComisionLogic comisionLogic = new ComisionLogic();
            if ((this.Modo == ApplicationForm.ModoForm.Alta) || (this.Modo == ApplicationForm.ModoForm.Modificacion))
            {
                try
                {
                    this.MapearADatos();
                    comisionLogic.Save(this.ComisionActual);
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
                    comisionLogic.Delete(ComisionActual.ID);
                    this.Close();
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        private void CargarCombo()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            //cmbEspecialidad.DataSource = el.GetAll();
            //cmbEspecialidad.DisplayMember = "Descripcion";
            //cmbEspecialidad.ValueMember = "Id";
        }


        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminacion de la comision" + this.ComisionActual.Descripcion + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.OK)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
#endregion