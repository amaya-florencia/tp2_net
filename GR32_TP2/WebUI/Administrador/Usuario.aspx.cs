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
    public partial class Usuario : ABMBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private UsuarioLogic _usrLogic;
        public UsuarioLogic UsrLogic
        {
            get 
            {
                if (_usrLogic == null)
                {
                    _usrLogic = new UsuarioLogic();
                }
                return _usrLogic;
            }
        }

        private Business.Entities.Usuario UsrEntity
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

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvUsuarios.SelectedValue;
        }

        public void LoadGrid()
        {
            this.dgvUsuarios.DataSource = this.UsrLogic.GetAll();
            this.dgvUsuarios.DataBind();
        }

        public void LoadForm(int id)
        {
            this.UsrEntity = this.UsrLogic.GetOne(id);
            this.txtUsuario.Text = this.UsrEntity.NombreUsuario;
            this.txtClave.Text = this.UsrEntity.Clave;
            this.txtNombre.Text = this.UsrEntity.Nombre;
            this.txtApellido.Text = this.UsrEntity.Apellido;
            this.chkHabilitado.Checked = this.UsrEntity.Habilitado;
        }

        private void LoadEntity(Business.Entities.Usuario usuario)
        {
            usuario.NombreUsuario = this.txtUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Habilitado = this.chkHabilitado.Checked;
        }

        private void SaveEntity(Business.Entities.Usuario usuario)
        {
            this.UsrLogic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            this.txtUsuario.Enabled = enable;
            this.txtClave.Enabled = enable;
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.chkHabilitado.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtUsuario.Text = string.Empty;
            this.txtClave.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.chkHabilitado.Checked = false;
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
            this.UsrLogic.Delete(id);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.UsrEntity = new Business.Entities.Usuario();
                        this.LoadEntity(this.UsrEntity);
                        this.SaveEntity(this.UsrEntity);
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
                        this.UsrEntity = new Business.Entities.Usuario();
                        this.UsrEntity.ID = this.SelectedID;
                        this.UsrEntity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.UsrEntity);
                        this.SaveEntity(this.UsrEntity);
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
