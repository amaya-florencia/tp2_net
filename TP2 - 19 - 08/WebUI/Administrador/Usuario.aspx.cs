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
        #region Propiedades
        UsuarioLogic _usrLogic;
        private UsuarioLogic Logic
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            this.dgvUsuarios.DataSource = this.Logic.GetAll();
            this.dgvUsuarios.DataBind();
        }


    }
}
