using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI
{
    public class ABMBase : System.Web.UI.Page
    {
        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

       
        public ModoForm FormModo
        {
            get { return(ModoForm)this.ViewState["FormModo"]; }
            set { this.ViewState["FormModo"] = value; }
        }

        public virtual void MapearDeDatos()
        {

        }

        public virtual void MapearADatos()
        {

        }

        public virtual void GuardarCambios()
        {

        }

        public virtual bool Validar()
        {
            return false;
        }

        /* public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
         {
             MessageBox.Show(mensaje, titulo, botones, icono);
         }

         public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
         {
             this.Notificar(this.Text, mensaje, botones, icono);
         }

         private void ApplicationForm_Load(object sender, EventArgs e)
         {

         }*/
    }
}