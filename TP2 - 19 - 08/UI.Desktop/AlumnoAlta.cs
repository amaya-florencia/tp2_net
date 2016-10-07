using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class AlumnoAlta : Form
    {
        private int id;
        private ApplicationForm.ModoForm modificacion;

        public AlumnoAlta()
        {
            InitializeComponent();
        }

        public AlumnoAlta(int id, ApplicationForm.ModoForm modificacion)
        {
            this.id = id;
            this.modificacion = modificacion;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
