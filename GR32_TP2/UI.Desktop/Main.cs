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
    public partial class Main : ApplicationForm
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
            this.PersonaActual = new PersonaLogic().GetOne(this.UsuarioActual.IdPersona);
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            string titulo = String.Format("Principal - {0}: {1} {2}", PersonaActual.TipoPersona.ToString(), PersonaActual.Nombre, PersonaActual.Apellido);
            this.Text = titulo;
            MostrarControlesPorTipoPersona();
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
            
            tsComisiones.Visible = false;
            tsInscripcion.Visible = false;
            tsCursos.Visible = false;
            tsEspecialidades.Visible = false;
            tsMaterias.Visible = false;
            tsAlumnos.Visible = false;
            tsPlanes.Visible = false;
            tsDocentes.Visible = false;
            tsUsuarios.Visible = false;

            switch (PersonaActual.TipoPersona)
            {
                case Enumeradores.TiposPersonas.Alumno:
                    {
                        ConfigurarMenuAlumno();
                        break;
                    }
                case Enumeradores.TiposPersonas.Administrador:
                    {
                        ConfigurarMenuAdministrador();
                        break;
                    }
                case Enumeradores.TiposPersonas.Docente:
                    {
                        ConfigurarMenuDocente();
                        break;
                    }
            }
        }

            private void ConfigurarMenuAdministrador()
        {
            try
            {
                //this.tsReportes.Visible = true;

                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                UsuarioActual.ModulosUsuario = mul.GetAll(UsuarioActual.ID);

                foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuario)
                {
                    if (mu.Modulo.Descripcion == "Usuarios")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsUsuarios.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Alumnos")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsAlumnos.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Docentes")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsDocentes.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Planes")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsPlanes.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Materias")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsMaterias.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Especialidades")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsEspecialidades.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Cursos")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsCursos.Visible = true;
                    }
                    else if (mu.Modulo.Descripcion == "Comisiones")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsComisiones.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Notificar(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MateriasABM formMaterias = new MateriasABM();
            formMaterias.ShowDialog();
        }

        private void tsCursos_Click(object sender, EventArgs e)
        {
            CursosABM formCursos = new CursosABM();
            formCursos.ShowDialog();
        }

        private void tsComisiones_Click(object sender, EventArgs e)
        {
            ComisionesABM formComisiones = new ComisionesABM();
            formComisiones.ShowDialog();
        }

        private void tsDocentes_Click(object sender, EventArgs e)
        {
            
            PersonaABM formPersonaABM = new PersonaABM(Enumeradores.TiposPersonas.Docente);
            formPersonaABM.ShowDialog();
        }

        private void tsAlumnos_Click(object sender, EventArgs e)
        {
            PersonaABM formPersonaABM = new PersonaABM(Enumeradores.TiposPersonas.Alumno);
            formPersonaABM.ShowDialog();
        }

        private void mnuCambiaClave_Click(object sender, EventArgs e)
        {
            CambioContraseña formCambio = new CambioContraseña(UsuarioActual);
            formCambio.ShowDialog();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Reportes.MateriasPorPlan formrep = new Reportes.MateriasPorPlan();
          //  formrep.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePlan.RepPlan formReporte = new ReportePlan.RepPlan();
            formReporte.ShowDialog();
        }
    }
}
