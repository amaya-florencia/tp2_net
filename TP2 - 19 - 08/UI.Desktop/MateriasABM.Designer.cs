namespace UI.Desktop
{
    partial class MateriasABM
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
            this.tsmNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNuevo,
            this.tsmEditar,
            this.tsmEliminar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmNuevo
            // 
            this.tsmNuevo.Image = global::UI.Desktop.Properties.Resources.tsbNuevo_Image;
            this.tsmNuevo.Name = "tsmNuevo";
            this.tsmNuevo.Size = new System.Drawing.Size(28, 20);
            this.tsmNuevo.Click += new System.EventHandler(this.tsmNuevo_Click);
            // 
            // tsmEditar
            // 
            this.tsmEditar.Image = global::UI.Desktop.Properties.Resources.tsbEditar_Image;
            this.tsmEditar.Name = "tsmEditar";
            this.tsmEditar.Size = new System.Drawing.Size(28, 20);
            this.tsmEditar.Click += new System.EventHandler(this.tsmEditar_Click);
            // 
            // tsmEliminar
            // 
            this.tsmEliminar.Image = global::UI.Desktop.Properties.Resources.tsbEliminar_Image;
            this.tsmEliminar.Name = "tsmEliminar";
            this.tsmEliminar.Size = new System.Drawing.Size(28, 20);
            this.tsmEliminar.Click += new System.EventHandler(this.tsmEliminar_Click);
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterias.Location = new System.Drawing.Point(0, 24);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.Size = new System.Drawing.Size(652, 292);
            this.dgvMaterias.TabIndex = 1;
            // 
            // MateriasABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 316);
            this.Controls.Add(this.dgvMaterias);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MateriasABM";
            this.Text = "MateriasABM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmNuevo;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmEditar;
        private System.Windows.Forms.ToolStripMenuItem tsmEliminar;
    }
}