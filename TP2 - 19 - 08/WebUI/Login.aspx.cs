using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbOlvidePass_Click(object sender, EventArgs e)
        {
            string script = @"<script type='text/javascript'>
                            alert('Haga memoria');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}