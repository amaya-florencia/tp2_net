using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace WebUI.Administrador
{
    public partial class Curso : ABMBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }

        CursosLogic _curLogic;
        private CursosLogic CurLogic
        {
            get
            {
                if (_curLogic == null)
                {
                    _curLogic = new CursosLogic();
                }
                return _curLogic;
            }
        }

        private Business.Entities.Curso CurEntity
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
        protected void dgvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvCursos.SelectedValue;
        }

        public void LoadGrid()
        {
            this.dgvCursos.DataSource = this.CurLogic.GetAll();
            this.dgvCursos.DataBind();
        }
        public void LoadForm(int id)
        {
            this.CurEntity = this.CurLogic.GetOne(id);
            this.txtDescripcion.Text = this.CurEntity.Descripcion;
            this.txtAnioCalendario.Text = this.CurEntity.AnioCalendario.ToString();
            this.txtCupo.Text = this.CurEntity.Cupo.ToString();
            this.ddlMateria.Text = this.CurEntity.IdMAteria.ToString();
            this.ddlComision.Text = this.CurEntity.IdComision.ToString();
        }

        private void LoadEntity(Business.Entities.Curso curso)
        {
            curso.Descripcion = this.txtDescripcion.Text;
            curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            curso.IdMAteria = Convert.ToInt32(this.ddlMateria.SelectedValue);
            curso.IdComision = Convert.ToInt32(this.ddlComision.SelectedValue);
        }

        private void SaveEntity(Business.Entities.Curso curso)
        {
            this.CurLogic.Save(curso);
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.txtAnioCalendario.Enabled = enable;
            this.txtCupo.Enabled = enable;
            this.ddlMateria.Enabled = enable;
            this.ddlComision.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
        }

        #endregion

        #region ActionsButttons

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
            this.CurLogic.Delete(id);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.CurEntity = new Business.Entities.Curso();
                        this.LoadEntity(this.CurEntity);
                        this.SaveEntity(this.CurEntity);
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
                        this.CurEntity = new Business.Entities.Curso(); 
                        this.CurEntity.ID = this.SelectedID;
                        this.CurEntity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.CurEntity);
                        this.SaveEntity(this.CurEntity);
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