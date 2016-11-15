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
    public partial class Plan : ABMBase
    {
        private Business.Entities.Plan PlanActual { get; set; }
        PlanLogic _planLogic;
        private PlanLogic PlanesLogic
        {
            get
            {
                if (_planLogic == null)
                {
                    _planLogic = new PlanLogic();
                }
                return _planLogic;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }
        private Business.Entities.Plan PlanEntity
        {
            get;
            set;
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private int SelectedId
        {
            get
            {
                if (this.ViewState["SelectedId"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {return 0;}
            }
            set { this.ViewState["SelecdID"] = value; }
        }
        private bool IsEntitySelected
        {
            get { return (this.SelectedId != 0); }
        }
        protected void dgvPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.dgvPlanes.SelectedValue;
        }
        public void LoadGrid()
        {
            this.dgvPlanes.DataSource = this.PlanesLogic.GetAll();
            this.dgvPlanes.DataBind();
        }

        public void LoadForm(int id)
        {
            this.dgvPlanes.DataSource = this.PlanesLogic.GetOne(id);
            this.txtDescripcion.Text = this.PlanEntity.Descripcion;
            this.cmbEspecialidad.Text = this.PlanEntity.IdEspecialidad.ToString();
        }
        private void LoadEntity(Business.Entities.Plan plan)
        {
            plan.Descripcion = this.txtDescripcion.Text;
            plan.IdEspecialidad = Convert.ToInt32(this.cmbEspecialidad.SelectedValue);
        }
        private void  SaveEntity(Business.Entities.Plan plan)
        {
            this.PlanesLogic.Save(plan);
        }
        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.cmbEspecialidad.Enabled = enable;
        }
        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;         
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {  this.formPanel.Visible = true;
           this.FormMode = FormModes.Alta;
           this.ClearForm();
           this.EnableForm(true);
         }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            this.EnableForm(true);
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedId);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
            }
        }
        private void DeleteEntity(int id)
        {
            this.PlanesLogic.Delete(id);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.PlanEntity = new Business.Entities.Plan();
                        this.LoadEntity(this.PlanEntity);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedId);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.PlanEntity = new Business.Entities.Plan();
                        this.PlanEntity.ID = this.SelectedId;
                        this.PlanEntity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.PlanEntity);
                        this.SaveEntity(this.PlanEntity);
                        this.LoadGrid();
                        break;
                    }
                default: { break; }
            }
            this.formPanel.Visible = false;
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ Main.aspx");
        }
    }

}
