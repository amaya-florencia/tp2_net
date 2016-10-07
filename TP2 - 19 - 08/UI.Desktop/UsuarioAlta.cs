using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class UsuarioAlta : ApplicationForm
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        public UsuarioAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public UsuarioAlta()
        {
            InitializeComponent();
        }
        public UsuarioAlta(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            try
            {
                this.UsuarioActual = usuarioLogic.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Usuario";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.Text = "Baja de Usuario";
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.Text = "Consulta de Usuario";
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                Usuario usr = new Usuario();
                this.UsuarioActual = usr;
            }
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Clave = this.txtConfirmarClave.Text;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            if ((this.Modo == ApplicationForm.ModoForm.Alta) || (this.Modo == ApplicationForm.ModoForm.Modificacion))
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario
                    usuarioLogic.Save(UsuarioActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    //Elimino el usuario
                    usuarioLogic.Delete(UsuarioActual.ID);
                    this.Close();
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override bool Validar()
        {
            bool valida = false;
            RegexUtilities util = new RegexUtilities();
            string mensaje = "";
            if (txtApellido.Text.Trim() == "")
                mensaje += "El apellido no puede estar en blanco." + "\n";
            if (txtNombre.Text.Trim() == "")
                mensaje += "El nombre no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                mensaje += "El usuario no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
                mensaje += "La clave no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
                mensaje += "El repetir clave no puede estar en blanco." + "\n";
            if (txtConfirmarClave.Text.Trim() != txtClave.Text.Trim())
                mensaje += "Las claves no coinciden." + "\n";
            if (txtClave.Text.Length < 8)
                mensaje += "La clave debe contener al menos 8 caracteres." + "\n";

            if (!string.IsNullOrEmpty(mensaje))
            {
                this.Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valida = true;
            }

            return valida;
        }



        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminacion del usuario" + this.UsuarioActual.Apellido + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.OK)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }

        }
    }
}
