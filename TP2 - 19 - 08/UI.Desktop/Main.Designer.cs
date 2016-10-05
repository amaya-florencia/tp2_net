namespace UI.Desktop
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.tsEspecialidades,
            this.tsPlanes,
            this.tsMaterias,
            this.tsComisiones,
            this.tsAlumnos,
            this.tsDocentes,
            this.tsUsuarios,
            this.tsInscripcion,
            this.tsCursos});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mnsPrincipal";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // tsEspecialidades
            // 
            this.tsEspecialidades.Name = "tsEspecialidades";
            this.tsEspecialidades.Size = new System.Drawing.Size(95, 20);
            this.tsEspecialidades.Text = "Especialidades";
            this.tsEspecialidades.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // tsPlanes
            // 
            this.tsPlanes.Name = "tsPlanes";
            this.tsPlanes.Size = new System.Drawing.Size(53, 20);
            this.tsPlanes.Text = "Planes";
            this.tsPlanes.Click += new System.EventHandler(this.tsPlanes_Click);
            // 
            // tsMaterias
            // 
            this.tsMaterias.Name = "tsMaterias";
            this.tsMaterias.Size = new System.Drawing.Size(64, 20);
            this.tsMaterias.Text = "Materias";
            this.tsMaterias.Click += new System.EventHandler(this.tsMaterias_Click);
            // 
            // tsComisiones
            // 
            this.tsComisiones.Name = "tsComisiones";
            this.tsComisiones.Size = new System.Drawing.Size(81, 20);
            this.tsComisiones.Text = "Comisiones";
            // 
            // tsAlumnos
            // 
            this.tsAlumnos.Name = "tsAlumnos";
            this.tsAlumnos.Size = new System.Drawing.Size(67, 20);
            this.tsAlumnos.Text = "Alumnos";
            // 
            // tsDocentes
            // 
            this.tsDocentes.Name = "tsDocentes";
            this.tsDocentes.Size = new System.Drawing.Size(68, 20);
            this.tsDocentes.Text = "Docentes";
            // 
            // tsUsuarios
            // 
            this.tsUsuarios.Name = "tsUsuarios";
            this.tsUsuarios.Size = new System.Drawing.Size(64, 20);
            this.tsUsuarios.Text = "Usuarios";
            this.tsUsuarios.Click += new System.EventHandler(this.tsUsuarios_Click);
            // 
            // tsInscripcion
            // 
            this.tsInscripcion.Name = "tsInscripcion";
            this.tsInscripcion.Size = new System.Drawing.Size(77, 20);
            this.tsInscripcion.Text = "Inscripción";
            // 
            // tsCursos
            // 
            this.tsCursos.Name = "tsCursos";
            this.tsCursos.Size = new System.Drawing.Size(55, 20);
            this.tsCursos.Text = "Cursos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(884, 404);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem tsEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsComisiones;
        private System.Windows.Forms.ToolStripMenuItem tsAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsDocentes;
        private System.Windows.Forms.ToolStripMenuItem tsUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsInscripcion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsCursos;
    }
}