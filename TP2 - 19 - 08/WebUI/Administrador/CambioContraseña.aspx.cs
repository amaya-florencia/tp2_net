using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace WebUI.Administrador
{
    public partial class CambioContraseña : ABMBase 
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public CambioContraseña()
        {
            //  InitializeComponent();
        }
        public CambioContraseña(Business.Entities.Usuario u) : this()
        {
            this.UsuarioActual = u;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "Notificar();", true);
            if (this.Validar())
            {
                this.GuardarCambios();
                Response.Redirect("~/Main.aspx");
            }
        }

        private Business.Entities.Usuario _usuarioActual;
        public Business.Entities.Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public override void GuardarCambios()

        {
            try
            {
                this.MapearADatos();
                new UsuarioLogic().Save(this.UsuarioActual);
            }
            catch (Exception e)
            {
                string script = @"<script type='text/javascript'>
                            alert('Error al guardar cambios');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
               // ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "Notificar(mensaje);", true);
            }
        }

        public override void MapearADatos()
        {
            this.UsuarioActual.State = BusinessEntity.States.Modified;
            this.UsuarioActual.Clave = this.txtClave.Text.Trim();
        }

        public override bool Validar()
        {
            string mensaje = "";
            if (String.IsNullOrEmpty(txtClave.Text))
            {
                mensaje += "Debe completar la contraseña\n";
            }
            if (String.IsNullOrEmpty(txtConfirmar.Text))
            {
                mensaje += "Debe confirmar la contraseña\n";
            }
            if (txtClave.Text.Trim() != txtConfirmar.Text.Trim())
            {
                mensaje += "Las claves ingresadas no coinciden\n";
            }
            if (!Validaciones.ValidarPassword(txtClave.Text))
            {
                mensaje += "La clave debe tener 8 o más caracteres\n";
            }
            if (mensaje.Length == 0)
            {
                return true;
            }
            else
            {
                string script = @"<script type='text/javascript'>
                            alert('Las claves no coinciden');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

    }
}