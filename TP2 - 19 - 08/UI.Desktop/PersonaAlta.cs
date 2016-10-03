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
        }
        public PersonaAlta()
        {
            InitializeComponent();
        }

        public PersonaAlta(int ID, ModoForm modo) : this()
        {
            Modo = modo;
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
                PersonaActual.IdPlan = this.cmbPlan.SelectedItem.GetHashCode();
             //   PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)tipoPersona;

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
                PersonaActual.IdPlan = this.cmbPlan.SelectedItem.GetHashCode();
            //    PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)tipoPersona;

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
            this.MapearADatos();
            PersonaLogic personaLog = new PersonaLogic();
            personaLog.Save(PersonaActual);
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
            bool valida = this.Validar();
            if (valida)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PersonaAlta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academia2DataSet1.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter1.Fill(this.academia2DataSet1.planes);
            // TODO: esta línea de código carga datos en la tabla 'academia2DataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.academia2DataSet.planes);

        }
    }
}
