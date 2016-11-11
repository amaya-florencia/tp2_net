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


        #region Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarGrilla();
                this.PanelIngresoDatos.Visible = false;
            }

           
        }

        private void CargarGrilla()
        {
            this.dgvEspecialidades.DataSource = this.Logic.GetAll();
            this.dgvEspecialidades.DataBind();
           
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
            EspecialidadActual.Descripcion= this.txtDescripcion.Text;
        }

        private void ClearForm()
        {
            this.txtId.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            
        }

        private void SaveEntity(Business.Entities.Especialidad esp)
        {
            this.Logic.Save(esp);
        }
        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        #endregion

        #region ActionsButtons 

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.EspecialidadActual = new Business.Entities.Especialidad();
                        this.LoadEntity(this.EspecialidadActual);
                        this.SaveEntity(this.EspecialidadActual);
                        this.CargarGrilla();
                        break;
                    }
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.CargarGrilla();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.EspecialidadActual = new Business.Entities.Especialidad();
                        this.EspecialidadActual.ID = this.SelectedID;
                        this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.EspecialidadActual);
                        this.SaveEntity(this.EspecialidadActual);
                        this.CargarGrilla();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            this.PanelIngresoDatos.Visible = false;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            this.EnableForm(true);
            if (this.IsEntitySelected)
            {
                this.btnAceptar.Text = "Guardar Cambios";
                this.PanelIngresoDatos.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
       

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.PanelIngresoDatos.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.btnAceptar.Text = "Eliminar";
            }
        }
       

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.PanelIngresoDatos.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.btnAceptar.Text = "Crear";
        }
        #endregion
    }

}