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
        }
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
       
    }
}
