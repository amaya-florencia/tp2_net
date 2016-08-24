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
            Modo = modo;
            
        }

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        private void UsuarioAlta_Load(object sender, EventArgs e)
        {

        }

        private void lblTipoDoc_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.cmbTipoDoc.Text = this.UsuarioActual.TipoDocumento;
            this.dtpFechaNacimiento.Value = this.UsuarioActual.FechaNac;
            //this.txtFechaNac.Text = this.UsuarioActual.FechaNac.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtDireccion.Text = this.UsuarioActual.Direccion;
            this.txtTelefono.Text = this.UsuarioActual.Telefono;
            this.txtCelular.Text = this.UsuarioActual.Celular;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            if((Modo == ModoForm.Alta) || (Modo == ModoForm.Modificacion))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usr = new Usuario();
                this.UsuarioActual = usr;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Clave = this.txtConfirmarClave.Text;
                UsuarioActual.TipoDocumento = this.cmbTipoDoc.Text;
                UsuarioActual.NroDocumento = this.txtNroDoc.Text;
                //UsuarioActual.FechaNac = Convert.ToDateTime(this.txtFechaNac.Text);
                UsuarioActual.FechaNac = this.dtpFechaNacimiento.Value;
                UsuarioActual.Direccion = this.txtDireccion.Text;
                UsuarioActual.Telefono = this.txtTelefono.Text;
                UsuarioActual.Celular = this.txtCelular.Text;

                UsuarioActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.ID = Convert.ToInt32(this.txtId.Text);
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Clave = this.txtConfirmarClave.Text;
                UsuarioActual.TipoDocumento = this.cmbTipoDoc.Text;
                UsuarioActual.NroDocumento = this.txtNroDoc.Text;
                //UsuarioActual.FechaNac = Convert.ToDateTime(this.txtFechaNac.Text);
                UsuarioActual.FechaNac = this.dtpFechaNacimiento.Value;
                UsuarioActual.Direccion = this.txtDireccion.Text;
                UsuarioActual.Telefono = this.txtTelefono.Text;
                UsuarioActual.Celular = this.txtCelular.Text;
                // UsuarioActual.Habilitado = this.chkHabilitado.Checked;

                UsuarioActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = Usuario.States.Deleted;
            }

        }

        public virtual void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usuarioLog = new UsuarioLogic();
            usuarioLog.Save(UsuarioActual);
        }

        public virtual bool Validar()
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valida = this.Validar();
            if (valida)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            UsuarioLogic usrLog = new UsuarioLogic();

            if (this.txtClave.Text == this.txtConfirmarClave.Text)
            {
                Usuario usr = new Usuario();
                usr.NombreUsuario = this.txtUsuario.Text;
                usr.Clave = this.txtClave.Text;
                usr.Habilitado = this.chkHabilitado.Checked;
                /*usr.TipoDocumento = this.cmbTipoDoc.Text;
                usr.NroDocumento = this.txtNroDoc.Text;*/
                usr.Nombre = this.txtNombre.Text;
                usr.Apellido = this.txtApellido.Text;
                usr.Email = this.txtEmail.Text;
                /*usr.Direccion = this.txtDireccion.Text;
                usr.Telefono = this.txtTelefono.Text;
                usr.Celular = this.txtCelular.Text;
                usr.FechaNac = this.dtpFechaNacimiento.Value;
                */
                usrLog.Save(usr);
            }
            else
            {
                MessageBox.Show("Las claves no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)//btnBuscar
        {
            UsuarioLogic usrLog = new UsuarioLogic();
            Usuario usr= usrLog.GetOne(Convert.ToInt32(this.txtId.Text));
            this.txtUsuario.Text=usr.NombreUsuario;
            this.txtClave.Text=usr.Clave;
            this.chkHabilitado.Checked=usr.Habilitado;
            /*usr.TipoDocumento = this.cmbTipoDoc.Text;
            usr.NroDocumento = this.txtNroDoc.Text;*/
            this.txtNombre.Text=usr.Nombre;
            this.txtApellido.Text=usr.Apellido;
            this.txtEmail.Text=usr.Email;
            /*usr.Direccion = this.txtDireccion.Text;
            usr.Telefono = this.txtTelefono.Text;
            usr.Celular = this.txtCelular.Text;
            usr.FechaNac = this.dtpFechaNacimiento.Value;
            */
        }
    }
}
