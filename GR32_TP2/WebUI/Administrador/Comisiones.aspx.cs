using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Util;

namespace WebUI.Administrador
{
    public partial class Comisiones : ABMBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }

        ComisionLogic _comLogic;
        private ComisionLogic ComLogic
        {
            get
            {
                if (_comLogic == null)
                {
                    _comLogic = new ComisionLogic();
                }
                return _comLogic;
            }
        }

        private Business.Entities.Comision ComEntity
        {
            get;
            set;
        }


        #region EstoDeberiaIrEnLaClasePadre
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

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        #endregion

        #region Metodos
        protected void dgvComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvComisiones.SelectedValue;
        }

        public void LoadGrid()
        {
            this.dgvComisiones.DataSource = this.ComLogic.GetAll();
            this.dgvComisiones.DataBind();
        }
        private void LoadForm(int id)
        {
            this.ComEntity = this.ComLogic.GetOne(id);
            this.txtDescripcion.Text = this.ComEntity.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComEntity.AnioEspecialidad.ToString();
            this.cmbPlan.Text = this.ComEntity.IdPlan.ToString();
        }

        private void LoadEntity(Business.Entities.Comision comision)
        {
            comision.Descripcion = this.txtDescripcion.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
            comision.IdPlan = Convert.ToInt32(this.cmbPlan.SelectedValue);
        }

        private void SaveEntity(Business.Entities.Comision comision)
        {
            this.ComLogic.Save(comision);
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.txtAnioEspecialidad.Enabled = enable;
            this.cmbPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtAnioEspecialidad.Text = string.Empty;
        }
        #endregion

        #region ActionsButtons
        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
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
                this.LoadForm(this.SelectedID);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.ComLogic.Delete(id);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.ComEntity = new Business.Entities.Comision();
                        this.LoadEntity(this.ComEntity);
                        this.SaveEntity(this.ComEntity);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.ComEntity = new Business.Entities.Comision();
                        this.ComEntity.ID = this.SelectedID;
                        this.ComEntity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.ComEntity);
                        this.SaveEntity(this.ComEntity);
                        this.LoadGrid();
                        break;
                    }
                default:
                    {
                        break;
                    }     
            }

            this.formPanel.Visible = false;
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        #endregion
    }
}