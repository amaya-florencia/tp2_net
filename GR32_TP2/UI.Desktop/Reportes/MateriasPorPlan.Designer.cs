namespace UI.Desktop.Reportes
{
    partial class MateriasPorPlan
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
            this.components = new System.ComponentModel.Container();
            this.rvMateriasPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dsMateriasPlanes1 = new UI.Desktop.Reportes.dsMateriasPlanes();
            this.MateriasPorPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesMateriasTableAdapter = new UI.Desktop.Reportes.dsMateriasPlanesTableAdapters.PlanesMateriasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriasPlanes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MateriasPorPlanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvMateriasPlanes
            // 
            this.rvMateriasPlanes.Location = new System.Drawing.Point(0, 56);
            this.rvMateriasPlanes.Name = "rvMateriasPlanes";
            this.rvMateriasPlanes.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rvMateriasPlanes.Size = new System.Drawing.Size(835, 299);
            this.rvMateriasPlanes.TabIndex = 0;
            this.rvMateriasPlanes.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(835, 49);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Especialidad:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(100, 12);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cmbEspecialidad.TabIndex = 3;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbPlan
            // 
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(420, 12);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(121, 21);
            this.cmbPlan.TabIndex = 4;
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plan:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(661, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Listar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dsMateriasPlanes1
            // 
            this.dsMateriasPlanes1.DataSetName = "dsMateriasPlanes";
            this.dsMateriasPlanes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MateriasPorPlanBindingSource
            // 
            this.MateriasPorPlanBindingSource.DataMember = "PlanesMaterias";
            this.MateriasPorPlanBindingSource.DataSource = this.dsMateriasPlanes1;
            this.MateriasPorPlanBindingSource.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged_1);
            // 
            // planesMateriasTableAdapter
            // 
            this.planesMateriasTableAdapter.ClearBeforeFill = true;
            // 
            // MateriasPorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rvMateriasPlanes);
            this.Name = "MateriasPorPlan";
            this.Text = "MateriasPorPlan";
            this.Load += new System.EventHandler(this.MateriasPorPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriasPlanes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MateriasPorPlanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvMateriasPlanes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private dsMateriasPlanes dsMateriasPlanes1;
        private System.Windows.Forms.BindingSource MateriasPorPlanBindingSource;
        private dsMateriasPlanesTableAdapters.PlanesMateriasTableAdapter planesMateriasTableAdapter;
    }
}