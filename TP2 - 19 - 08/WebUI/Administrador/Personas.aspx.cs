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
        #region Propiedades/Variables
        Enumeradores.TiposPersonas tipoPersona = Enumeradores.TiposPersonas.Alumno;

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
        private Business.Entities.Persona PersonaEntity
        {
            get;
            set;
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            this.txtFechaNacimiento.Text = DateTime.Today.ToShortDateString();
            /*             
            this.cmbRol.DataSource = Enum.GetNames(typeof(Util.Enumeradores.TiposPersonas));
            */
            if (!IsPostBack)
            {
                this.LoadGrid();
            }

        }
        public void LoadGrid()
        {

            this.dgvPersonas.DataSource = this.PerLogic.GetAll(this.tipoPersona);
            this.dgvPersonas.DataBind();
        }

        protected void dgvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvPersonas.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.PersonaEntity = this.PerLogic.GetOne(id);
            this.txtNombre.Text = this.PersonaEntity.Nombre;
            this.txtApellido.Text = this.PersonaEntity.Apellido;
            this.txtDireccion.Text = this.PersonaEntity.Direccion;
            this.txtEmail.Text = this.PersonaEntity.Email;
            this.txtTelefono.Text = this.PersonaEntity.Telefono;
            this.txtFechaNacimiento.Text = this.PersonaEntity.FechaNac.ToString();
            this.txtLegajo.Text = this.PersonaEntity.Legajo.ToString();
            this.cmbPlan.Text = this.PersonaEntity.IdPlan.ToString();
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
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

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            this.PersonaEntity = new Business.Entities.Persona();
            this.PersonaEntity.ID = this.SelectedID;
            this.PersonaEntity.State = Business.Entities.BusinessEntity.States.Modified;
            this.LoadEntity(this.PersonaEntity);
            this.SaveEntity(this.PersonaEntity);
            this.LoadGrid();

            this.formPanel.Visible = false;
        }



        /*
        public void Listar(Enumeradores.TiposPersonas tipoPersona)
        {
             PersonaLogic pl = new PersonaLogic();
             try
             {
                 this.dgvPersonas.DataSource = pl.GetAll(tipoPersona);
             }
             catch (Exception Ex)
             {
               //MessageBox.Show("Error al llenar la grilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.lblMensaje.Text = "Error al llenar la grilla.";
             }
         }        
        */
    }
}