using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Logic;
using Util;

namespace WebUI
{
    public class ABMBase : System.Web.UI.Page
    {
        
        protected int _idUsuarioActual;
        protected int IdUsuarioActual
        {
            get
            {
                if (_idUsuarioActual == 0)
                {
                    return Int32.Parse(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    return _idUsuarioActual;
                }
            }
        }
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

        
        protected int SelectedID
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
        protected bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        public virtual void GuardarCambios() { }

        public virtual void MapearADatos() { }

        public virtual void LoadForm(int id)
        {

        }
        public virtual bool Validar()
        {
            return false;
        }

       
    }
}