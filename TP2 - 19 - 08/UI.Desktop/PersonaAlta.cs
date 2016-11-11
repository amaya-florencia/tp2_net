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
        public PersonaAlta(Enumeradores.TiposPersonas tipoPer) : this()
        {
            
            //this.cmbTipoPersona.Text = tipoPer.ToString();

            this.txtTipoPersona.Text = tipoPer.ToString();

            // this.cmbTipoPersona.Enabled = false;
            this.txtTipoPersona.Text = tipoPer.ToString();
            this.txtTipoPersona.Enabled = false;

        }
        public PersonaAlta()
        {
            InitializeComponent();
            cargarCombos();
        }

        private void cargarCombos()
        {
            cmbTipoPersona.DataSource = Enum.GetNames(typeof(Util.Enumeradores.TiposPersonas));
        }

        public PersonaAlta(int ID, ModoForm modo, Enumeradores.TiposPersonas tipoPer) : this()
        {
            if (modo == ModoForm.Modificacion || modo == ModoForm.Baja)
            {                
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
            this.udLegajo.Value = this.PersonaActual.Legajo;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.cmbPlan.Text = this.PersonaActual.IdPlan.ToString();
            this.txtTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
            this.cmbTipoPersona.SelectedIndex = (int)this.PersonaActual.TipoPersona;

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
                PersonaActual = new Persona();
                PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)this.cmbTipoPersona.SelectedIndex;

            }

            if ((Modo == ModoForm.Alta || Modo == ModoForm.Modificacion))
            {
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.FechaNac = this.dtpFechaNacimiento.Value;
                PersonaActual.Legajo = Convert.ToInt32(this.udLegajo.Value);
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.IdPlan = Convert.ToInt32(this.cmbPlan.SelectedValue);
                PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)this.cmbTipoPersona.SelectedIndex;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
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

        private void PersonaAlta_Load_1(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            cmbPlan.DataSource = pl.GetAll();
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "Id";
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
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
    }
}