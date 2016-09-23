using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void formMain_Shown(object sender, EventArgs e)
        {
            Login appLogin = new Login();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }

        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enum tipoPersona = Enumeradores.TiposPersonas.Docente;
            PersonaABM formPersonaABM = new PersonaABM(tipoPersona);
            formPersonaABM.ShowDialog();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enum tipoPersona = Enumeradores.TiposPersonas.Alumno;
            PersonaABM formPersonaABM = new PersonaABM(tipoPersona);
            formPersonaABM.ShowDialog();
        }
    }
}
