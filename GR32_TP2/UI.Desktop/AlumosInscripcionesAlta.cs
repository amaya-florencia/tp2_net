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

namespace UI.Desktop
{
    public partial class AlumosInscripcionesAlta : ApplicationForm
    {
        public AlumosInscripcionesAlta()
        {
            InitializeComponent();
        }

        private Persona _PersonaActual;

        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            this.PersonaActual = pl.GetOnebyLegajo(Convert.ToInt32(this.txtLegajo.Text));
            this.lblAlumno.Text = PersonaActual.Apellido + ", " + PersonaActual.Nombre;
            CargarGrilla(PersonaActual.ID);
        }

        private void CargarGrilla(int iD)
        {
           
        }
    }
}
