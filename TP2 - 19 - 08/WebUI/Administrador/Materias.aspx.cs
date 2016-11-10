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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            this.dgvMaterias.DataSource = this.Logic.GetAll();
            this.dgvMaterias.DataBind();
        }
    }
}