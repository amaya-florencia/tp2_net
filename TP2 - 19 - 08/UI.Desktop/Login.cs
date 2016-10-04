using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Usuario UsuarioLog { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        public void ValidaLogin()
        {
            try
            {
                if (this.Validar())
                {
                    UsuarioLog = new UsuarioLogic().GetOne(this.txtUsuario.Text.Trim(), this.txtPass.Text.Trim());
                    if (UsuarioLog !=null)
                    {
                        this.Notificar("Login", "Datos correctos. ¡Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Notificar("Login", "El usuario ingresado fue deshabilitado. Contáctese con un Administrador.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Notificar("Login", "Usuario y/o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                }
            }
            catch (Exception ex )
            {

                this.Notificar("Login", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            this.txtUsuario.Clear();
            this.txtPass.Clear();
            this.txtUsuario.Focus();
        }
        
        public override bool Validar()
        {
            string mensaje = "";
            if (String.IsNullOrEmpty(this.txtUsuario.Text))
            {
                mensaje += "Debe ingresar un nombre de usuario\n";
            }
            if (String.IsNullOrEmpty(this.txtPass.Text))
            {
                mensaje += "Debe ingresar una contraseña\n";
            }
            if (mensaje.Length > 0)
            {
                this.Notificar("Login", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }
    }
}
