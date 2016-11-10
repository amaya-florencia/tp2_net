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
    public partial class Persona : ABMBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtFechaNacimiento.Text = DateTime.Today.ToShortDateString();
            PlanLogic pLogic = new PlanLogic();
            this.dgvAlumnos.DataSource = 
            this.cmbPlan.DataSource = pLogic.GetAll();
            this.cmbRol.DataSource = Enum.GetNames(typeof(Util.Enumeradores.TiposPersonas));
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

         protected void btnEditar_Click(object sender, EventArgs e)
         {
 
         }

         protected void btnEliminar_Click(object sender, EventArgs e)
         {

         }


    }
}