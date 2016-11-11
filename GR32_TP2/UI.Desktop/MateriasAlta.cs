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
    public partial class MateriasAlta : ApplicationForm
    {
        #region Constructores
        public MateriasAlta()
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
        public MateriasAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public MateriasAlta(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.MateriaActual = ml.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Propiedades
        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }
        #endregion

        #region Metodos
        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                MateriaActual = new Materia();
            }
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.HsSemanales = Convert.ToInt32(this.udHorasSemanales.Value);
                MateriaActual.HsTotales = Convert.ToInt32(this.udHorasTotales.Value);
                MateriaActual.IdPlan = (int)this.cmbPlanes.SelectedValue;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.udHorasSemanales.Value = this.MateriaActual.HsSemanales;
            this.udHorasTotales.Value = this.MateriaActual.HsTotales;
            this.cmbPlanes.SelectedValue = this.MateriaActual.IdPlan;
            
            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Materia";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.txtDescripcion.ReadOnly = true;
                    this.Text = "Baja de Materia";
                    btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            if ((this.Modo == ApplicationForm.ModoForm.Alta) || (this.Modo == ApplicationForm.ModoForm.Modificacion))
            {
                try
                {
                    this.MapearADatos();
                    materiaLogic.Save(this.MateriaActual);
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
                    materiaLogic.Delete(MateriaActual.ID);
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
            PlanLogic pl = new PlanLogic();
            cmbPlanes.DataSource = pl.GetAll();
            cmbPlanes.DisplayMember = "Descripcion";
            cmbPlanes.ValueMember = "Id";
        }
        #endregion

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
                DialogResult rta = MessageBox.Show("Confirma la eliminacion del usuario" + this.MateriaActual.Descripcion + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
        #endregion
    }
}
