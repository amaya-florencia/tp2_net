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
    public partial class Personas : ABMBase
    {
        //falta determinar un parametro que especifique que tipo de persona es
        Enumeradores.TiposPersonas tipoPersona = Enumeradores.TiposPersonas.Alumno;
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
            if (!IsPostBack)
            {
                this.LoadGrid();
            }

        }

        PersonaLogic _perLogic;
        private PersonaLogic PerLogic 
        {
            get
            {
                if (_perLogic == null)
                {
                    _perLogic = new PersonaLogic();
                }
                return _perLogic;
            }
        }

        private Business.Entities.Persona PerEntity
        {
            get;
            set;
        }

      
     

        #region Metodos
        protected void dgvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvPersonas.SelectedValue;
        }

        public void LoadGrid()
        {
            
            this.dgvPersonas.DataSource = this.PerLogic.GetAll(this.tipoPersona);
            this.dgvPersonas.DataBind();
        }
        public override void LoadForm(int id)
        {
            this.PerEntity = this.PerLogic.GetOne(id);
            this.txtNombre.Text = this.PerEntity.Nombre;
            this.txtApellido.Text = this.PerEntity.Apellido;
            this.txtDireccion.Text = this.PerEntity.Direccion;
            this.txtEmail.Text = this.PerEntity.Email;
            this.txtTelefono.Text = this.PerEntity.Telefono;
            this.txtFechaNacimiento.Text = this.PerEntity.FechaNac.ToString();
            this.txtLegajo.Text = this.PerEntity.Legajo.ToString();
            this.cmbPlan.Text = this.PerEntity.IdPlan.ToString();
        }

        private void LoadEntity(Business.Entities.Persona persona)
        {
            persona.Nombre = this.txtNombre.Text;
            persona.Apellido = this.txtApellido.Text;
            persona.Direccion = this.txtDireccion.Text;
            persona.Email = this.txtEmail.Text;
            persona.Telefono = this.txtTelefono.Text;
            persona.FechaNac = Convert.ToDateTime(this.txtFechaNacimiento.Text);
            persona.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            persona.IdPlan = Convert.ToInt32(this.cmbPlan.SelectedValue);
        }

        private void SaveEntity(Business.Entities.Persona persona)
        {
            this.PerLogic.Save(persona);
        }

        private void EnableForm(bool enable)
        {
            this.txtId.Enabled = enable;
            this.txtNombre.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtFechaNacimiento.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.cmbPlan.Enabled = enable;
            this.cmbRol.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtFechaNacimiento.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
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
            if(this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.PerLogic.Detele(id);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.PerEntity = new Business.Entities.Persona();
                        this.LoadEntity(this.PerEntity);
                        this.SaveEntity(this.PerEntity);
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
                        this.PerEntity = new Business.Entities.Persona();
                        this.PerEntity.ID = this.SelectedID;
                        this.PerEntity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.PerEntity);
                        this.SaveEntity(this.PerEntity);
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