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
    public partial class Especialidad : ABMBase
    {   
        #region Propiedades
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
            this.CargarGrilla();
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}