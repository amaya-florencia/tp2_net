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
    public partial class Main : Form
    {

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        protected Persona PersonaActual { get; set; }
        public Main()
        {
            InitializeComponent();
        }
        public Main (Usuario usuarioLog): this()
        {
            this.UsuarioActual = usuarioLog;
           // this.PersonaActual = new PersonaLogic().GetOnePorPersona(this.UsuarioActual.IdPersona);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesAMB formEspecialidades = new EspecialidadesAMB(UsuarioActual);
            formEspecialidades.Show();
        }
        private void MostrarControlesPorTipoPersona()
        {
            //Inicialmente oculto todos los menues
            mnuArchivo.Visible = false;
            tsEspecialidades.Visible = false;
            tsPlanes.Visible = false;
            tsMaterias.Visible = false;
            tsComisiones.Visible = false;
            tsAlumnos.Visible = false;
            tsDocentes.Visible = false;
            tsUsuarios.Visible = false;

            switch (PersonaActual.TipoPersona)
            {
                case Enumeradores.TiposPersonas.Alumno:
                    {
                        ConfigurarMenuAlumno();
                        break;
                    }
                /*case Enumeradores.TiposPersonas.Administrador:
                    {
                        ConfigurarMenuAdministrador();
                        break;
                    }*/
                case Enumeradores.TiposPersonas.Docente:
                    {
                        ConfigurarMenuDocente();
                        break;
                    }
            }
        }
        private void ConfigurarMenuAlumno()
        {
            this.tsInscripcion.Text = "Estado Académico";
            this.tsInscripcion.Visible = true;
        }
        private void ConfigurarMenuDocente()
        {
            this.tsCursos.Text = "Mis Cursos";
            this.tsCursos.Visible = true;
        }

        private void tsUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosABM formUsuarios = new UsuariosABM();
            formUsuarios.Show();
        }

        private void tsPlanes_Click(object sender, EventArgs e)
        {
            PlanABM formPlan = new PlanABM();
            formPlan.Show();
        }

        private void tsMaterias_Click(object sender, EventArgs e)
        {
            MateriasABM FormMaterias = new MateriasABM();
            FormMaterias.ShowDialog();
        }
    }
}
