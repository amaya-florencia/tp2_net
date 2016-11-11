using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace WebUI.Administrador
{
    public partial class Especialidad : ABMBase
    {
        #region Propiedades/Variables
        private Business.Entities.Especialidad EspecialidadActual { get; set; }
        EspecialidadLogic _espLogic;
        private EspecialidadLogic Logic
        {
            get
            {
                if (_espLogic == null)
                {
                    _espLogic = new EspecialidadLogic();
                }
                return _espLogic;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarGrilla();
            }

           
        }

        private void CargarGrilla()
        {
            this.dgvEspecialidades.DataSource = this.Logic.GetAll();
            this.dgvEspecialidades.DataBind();
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            this.EspecialidadActual = new Business.Entities.Especialidad();
            this.EspecialidadActual.ID = this.SelectedID;
            this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Modified;
            this.LoadEntity(this.EspecialidadActual);
            this.SaveEntity(this.EspecialidadActual);
            this.CargarGrilla();
        }


        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvEspecialidades.SelectedValue;
        }

       
        public override void LoadForm(int id)
        {
            this.EspecialidadActual = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            this.txtId.Text = this.EspecialidadActual.ID.ToString();
            
        }

        private void LoadEntity(Business.Entities.Especialidad especialidad)
        {
            especialidad.Descripcion= this.txtDescripcion.Text;
        }

        private void SaveEntity(Business.Entities.Especialidad esp)
        {
            this.Logic.Save(esp);
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }
    }
}