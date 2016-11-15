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
    public partial class Materias : ABMBase

    {
        #region Propiedades
        MateriaLogic _matLogic;
        private Business.Entities.Materia MateriaActual { get; set; }
        private MateriaLogic Logic
        {
            get
            {
                if (_matLogic == null)
                {
                    _matLogic = new MateriaLogic();
                }
                return _matLogic;
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
            this.dgvMaterias.DataSource = this.Logic.GetAll();
            this.dgvMaterias.DataBind();
        }

        #endregion

        protected void dgvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvMaterias.SelectedValue;
        }

        public override void LoadForm(int id)
        {
            this.MateriaActual = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtIdMateria.Text = this.MateriaActual.ID.ToString();
            this.ddlPlan.Text = this.MateriaActual.IdPlan.ToString();
            this.txtHorasSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HsTotales.ToString();

        }

        private void LoadEntity(Business.Entities.Materia mat)
        {
            MateriaActual.Descripcion = this.txtDescripcion.Text;
            MateriaActual.IdPlan = Convert.ToInt32(this.ddlPlan.SelectedValue);
            MateriaActual.HsSemanales = Convert.ToInt32(this.txtHorasSemanales.Text);
            MateriaActual.HsTotales= Convert.ToInt32(this.txtHorasTotales.Text);
        }

        private void ClearForm()
        {
            this.txtIdMateria.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtHorasTotales.Text = string.Empty;
            this.txtHorasSemanales.Text = string.Empty;
            //this.ddlPlan.SelectedItem.Value = null;
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.ddlPlan.Enabled = enable;
            this.txtHorasSemanales.Enabled = enable;
            this.txtHorasTotales.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        private void SaveEntity(Business.Entities.Materia mat)
        {
            this.Logic.Save(mat);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }


        #region ActionsButtons


        #endregion

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.MateriaActual = new Business.Entities.Materia();
                        this.LoadEntity(this.MateriaActual);
                        this.SaveEntity(this.MateriaActual);
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
                        this.MateriaActual = new Business.Entities.Materia();
                        this.MateriaActual.ID = this.SelectedID;
                        this.MateriaActual.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.MateriaActual);
                        this.SaveEntity(this.MateriaActual);
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.PanelIngresoDatos.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.btnAceptar.Text = "Crear";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}