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
            this.cmbTipoDoc.Text = this.UsuarioActual.TipoDocumento;
           // this.dtpFechaNacimiento.Value = this.UsuarioActual.FechaNac;            
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtDireccion.Text = this.UsuarioActual.Direccion;
            this.txtTelefono.Text = this.UsuarioActual.Telefono;
            this.txtCelular.Text = this.UsuarioActual.Celular;
            this.txtEmail.Text = this.UsuarioActual.Email;
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
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo==ApplicationForm.ModoForm.Modificacion)
            {                  
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Clave = this.txtConfirmarClave.Text;
                UsuarioActual.TipoDocumento = this.cmbTipoDoc.Text;
                UsuarioActual.NroDocumento = this.txtNroDoc.Text;               
                UsuarioActual.FechaNac = this.dtpFechaNacimiento.Value;
                UsuarioActual.Direccion = this.txtDireccion.Text;
                UsuarioActual.Telefono = this.txtTelefono.Text;
                UsuarioActual.Celular = this.txtCelular.Text;                
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
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                mensaje += "El email no puede estar en blanco." + "\n";
            if (!util.validarMail(txtEmail.Text))
                mensaje += "El mail no tiene el formato correcto" + "\n";
            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
                mensaje += "La clave no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
                mensaje += "El repetir clave no puede estar en blanco." + "\n";
            if (txtConfirmarClave.Text.Trim() != txtClave.Text.Trim())
                mensaje += "Las claves no coinciden." + "\n";
            if (txtClave.Text.Length < 8)
                mensaje += "La clave debe contener al menos 8 caracteres." + "\n";
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
                mensaje += "La direccion no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtTelefono.Text.Trim()))
                mensaje += "el telefono no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtCelular.Text.Trim()))
                mensaje += "El celular  no puede estar en blanco." + "\n";
            /* if (string.IsNullOrEmpty(txtFechaNac.Text.Trim()))
                 mensaje += "La fecha de naciomiento no puede estar en blanco." + "\n";*/
            if (String.IsNullOrEmpty(this.dtpFechaNacimiento.Text))
            {
                mensaje += "- Complete la fecha de nacimiento\n";
            }
            if (string.IsNullOrEmpty(cmbTipoDoc.Text.Trim()))
                mensaje += "El tipo de documento no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtNroDoc.Text.Trim()))
                mensaje += "El numero de documento no puede estar en blanco." + "\n";
            if (txtNroDoc.Text.Length < 7 || txtNroDoc.Text.Length >8)
                mensaje += "El numero de documento esta mal ingresado." + "\n";

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
            #region
            /*
            UsuarioLogic usrLog = new UsuarioLogic();
            bool valido = this.Validar();

            if (this.txtClave.Text == this.txtConfirmarClave.Text)
            {
                Usuario usr = new Usuario();
                usr.NombreUsuario = this.txtUsuario.Text;
                usr.Clave = this.txtClave.Text;
                usr.Habilitado = this.chkHabilitado.Checked;
                //usr.TipoDocumento = this.cmbTipoDoc.Text;
                //usr.NroDocumento = this.txtNroDoc.Text;
                usr.Nombre = this.txtNombre.Text;
                usr.Apellido = this.txtApellido.Text;
                usr.Email = this.txtEmail.Text;
                //usr.Direccion = this.txtDireccion.Text;
                //usr.Telefono = this.txtTelefono.Text;
                //usr.Celular = this.txtCelular.Text;
                //usr.FechaNac = this.dtpFechaNacimiento.Value;
                
                usrLog.Save(usr);
            }
            else
            {
                MessageBox.Show("Las claves no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           this.Close();
           */
            #endregion

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
