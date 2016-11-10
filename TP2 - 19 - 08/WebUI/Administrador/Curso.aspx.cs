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
        #region Propiedades
        CursosLogic _cursoLogic;
        private CursosLogic Logic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursosLogic();
                }
                return _cursoLogic;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            this.dgvCursos.DataSource = this.Logic.GetAll();
            this.dgvCursos.DataBind();
        }
    }
}