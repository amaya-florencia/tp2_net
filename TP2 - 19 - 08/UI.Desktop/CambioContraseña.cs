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
using Util;


namespace UI.Desktop
{
    public partial class CambioContraseña : ApplicationForm
    {
        public CambioContraseña()
        {
            InitializeComponent();
        }
        public CambioContraseña(Usuario u) : this()
        {
            UsuarioActual = u;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }
       
            private Usuario _usuarioActual;
            public Usuario UsuarioActual
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
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.Notificar("Advertencia", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            private void btnCancelar_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }

