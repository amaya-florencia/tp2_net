﻿namespace UI.Desktop
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
            this.mnuCambiaClave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.verNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsCursos,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mnsPrincipal";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCambiaClave,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuCambiaClave
            // 
            this.mnuCambiaClave.Name = "mnuCambiaClave";
            this.mnuCambiaClave.Size = new System.Drawing.Size(151, 22);
            this.mnuCambiaClave.Text = "Cambiar Clave";
            this.mnuCambiaClave.Click += new System.EventHandler(this.mnuCambiaClave_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(151, 22);
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
            this.tsComisiones.Click += new System.EventHandler(this.tsComisiones_Click);
            // 
            // tsAlumnos
            // 
            this.tsAlumnos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verNotasToolStripMenuItem});
            this.tsAlumnos.Name = "tsAlumnos";
            this.tsAlumnos.Size = new System.Drawing.Size(67, 20);
            this.tsAlumnos.Text = "Alumnos";
            this.tsAlumnos.Click += new System.EventHandler(this.tsAlumnos_Click);
            // 
            // verNotasToolStripMenuItem
            // 
            this.verNotasToolStripMenuItem.Name = "verNotasToolStripMenuItem";
            this.verNotasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.verNotasToolStripMenuItem.Text = "Ver Notas";
            // 
            // tsDocentes
            // 
            this.tsDocentes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarNotasToolStripMenuItem});
            this.tsDocentes.Name = "tsDocentes";
            this.tsDocentes.Size = new System.Drawing.Size(68, 20);
            this.tsDocentes.Text = "Docentes";
            this.tsDocentes.Click += new System.EventHandler(this.tsDocentes_Click);
            // 
            // registrarNotasToolStripMenuItem
            // 
            this.registrarNotasToolStripMenuItem.Name = "registrarNotasToolStripMenuItem";
            this.registrarNotasToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.registrarNotasToolStripMenuItem.Text = "Registrar Notas";
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
            this.tsCursos.Click += new System.EventHandler(this.tsCursos_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(884, 404);
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
        private System.Windows.Forms.ToolStripMenuItem tsCursos;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCambiaClave;
        private System.Windows.Forms.ToolStripMenuItem verNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
    }
}