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
    public partial class PersonaAlta : ApplicationForm
    {
        public PersonaAlta(Enum tipoPer) : this()
        {          
            Enum tipoPersona = tipoPer;
            //this.cmbTipoPersona.DisplayMember = tipoPer.ToString();
            this.cmbTipoPersona.Text = tipoPer.ToString();

            this.txtTipoPersona.Text = tipoPer.ToString();

          // this.cmbTipoPersona.Enabled = false;
            this.txtTipoPersona.Text = tipoPer.ToString();
            this.txtTipoPersona.Enabled = false;
           
        }
        public PersonaAlta()
        {
            InitializeComponent();
        }

       public PersonaAlta(int ID, ModoForm modo, Enum tipoPer) : this()
        {
            this.cmbTipoPersona.Text = tipoPer.ToString();
            this.cmbTipoPersona.Enabled = false;

            Modo = modo;
            PersonaLogic personaLogic = new PersonaLogic();
            try
            {
                this.PersonaActual = personaLogic.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNac;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.cmbPlan.Text = this.PersonaActual.IdPlan.ToString();
            this.cmbTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();

            if ((Modo == ModoForm.Alta) || (Modo == ModoForm.Modificacion))
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
                Persona per = new Persona();
                this.PersonaActual = per;

                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.FechaNac = this.dtpFechaNacimiento.Value;
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.IdPlan = Convert.ToInt32(this.cmbPlan.SelectedValue);
                PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)this.cmbTipoPersona.SelectedItem;
                

                PersonaActual.State = Usuario.States.New;
            }

            if (Modo == ModoForm.Modificacion)
            {
                PersonaActual.ID = Convert.ToInt32(this.txtId.Text);
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.FechaNac = this.dtpFechaNacimiento.Value;
                PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.IdPlan = Convert.ToInt32(this.cmbPlan.SelectedValue);
                PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)this.cmbTipoPersona.SelectedItem;

                PersonaActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                PersonaActual.State = Usuario.States.Unmodified;
            }
            if (Modo == ModoForm.Baja)
            {
                PersonaActual.State = Usuario.States.Deleted;
            }

        }

        public virtual void GuardarCambios()
        {
            PersonaLogic personaLog = new PersonaLogic();
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.MapearADatos();
                personaLog.Save(PersonaActual);
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                try
                {
                    personaLog.Detele(PersonaActual.ID);
                }
                catch (Exception e)
                {
                    this.Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        public virtual bool Validar()
        {
            bool valida = false;
            RegexUtilities util = new RegexUtilities();

            string mensaje = "";
            if (txtNombre.Text.Trim() == "")
                mensaje += "El nombre no puede estar en blanco." + "\n";
            if (txtApellido.Text.Trim() == "")
                mensaje += "El apellido no puede estar en blanco." + "\n";
            
            /* Esto sí puede estar en blanco según la BD
             
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
                mensaje += "La direccion no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                mensaje += "El email no puede estar en blanco." + "\n";
            if (!util.validarMail(txtEmail.Text))
                mensaje += "El email no tiene el formato correcto" + "\n";
            if (string.IsNullOrEmpty(txtTelefono.Text.Trim()))
                mensaje += "El teléfono no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtLegajo.Text.Trim()))
                mensaje += "El legajo no puede estar en blanco." + "\n";
            if (string.IsNullOrEmpty(txtFechaNac.Text.Trim()))
                 mensaje += "La fecha de naciomiento no puede estar en blanco." + "\n";*/
            
            if (String.IsNullOrEmpty(this.dtpFechaNacimiento.Text))
            {
                mensaje += "- Complete la fecha de nacimiento\n";
            }
           
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
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                bool valida = this.Validar();
                if (valida)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminación de " + this.PersonaActual.Nombre + " " + this.PersonaActual.Apellido + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (rta == DialogResult.OK)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }

        }

        private void PersonaAlta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academia2DataSet1.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter1.Fill(this.academia2DataSet1.planes);
            // TODO: esta línea de código carga datos en la tabla 'academia2DataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.academia2DataSet.planes);

            cmbTipoPersona.DataSource = Enum.GetValues(typeof(Util.Enumeradores.TiposPersonas));

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
