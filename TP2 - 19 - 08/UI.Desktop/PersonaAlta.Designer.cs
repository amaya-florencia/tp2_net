namespace UI.Desktop
{
    partial class PersonaAlta
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
            this.tlpProfesor = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.planesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
        //    this.academia2DataSet1 = new UI.Desktop.academia2DataSet1();
            this.txtTipoPersona = new System.Windows.Forms.TextBox();
            this.tiposPersonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
       //     this.academia2DataSet = new UI.Desktop.academia2DataSet();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      //      this.planesTableAdapter = new UI.Desktop.academia2DataSetTableAdapters.planesTableAdapter();
      //      this.planesTableAdapter1 = new UI.Desktop.academia2DataSet1TableAdapters.planesTableAdapter();
            this.cmbTipoPersona = new System.Windows.Forms.ComboBox();
            this.tlpProfesor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource1)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.academia2DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposPersonasBindingSource)).BeginInit();
       //     ((System.ComponentModel.ISupportInitialize)(this.academia2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpProfesor
            // 
            this.tlpProfesor.AutoScroll = true;
            this.tlpProfesor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpProfesor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpProfesor.ColumnCount = 4;
            this.tlpProfesor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpProfesor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpProfesor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpProfesor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpProfesor.Controls.Add(this.lblNombre, 0, 1);
            this.tlpProfesor.Controls.Add(this.btnCancelar, 3, 5);
            this.tlpProfesor.Controls.Add(this.btnAceptar, 2, 5);
            this.tlpProfesor.Controls.Add(this.txtId, 1, 0);
            this.tlpProfesor.Controls.Add(this.lblId, 0, 0);
            this.tlpProfesor.Controls.Add(this.txtApellido, 3, 1);
            this.tlpProfesor.Controls.Add(this.lblApellido, 2, 1);
            this.tlpProfesor.Controls.Add(this.lblTelefono, 2, 3);
            this.tlpProfesor.Controls.Add(this.txtTelefono, 3, 3);
            this.tlpProfesor.Controls.Add(this.lblFechaNac, 0, 2);
            this.tlpProfesor.Controls.Add(this.txtNombre, 1, 1);
            this.tlpProfesor.Controls.Add(this.dtpFechaNacimiento, 1, 2);
            this.tlpProfesor.Controls.Add(this.btnBuscar, 2, 0);
            this.tlpProfesor.Controls.Add(this.txtEmail, 1, 4);
            this.tlpProfesor.Controls.Add(this.lblEmail, 0, 4);
            this.tlpProfesor.Controls.Add(this.lblDireccion, 0, 3);
            this.tlpProfesor.Controls.Add(this.txtDireccion, 1, 3);
            this.tlpProfesor.Controls.Add(this.lblLegajo, 2, 2);
            this.tlpProfesor.Controls.Add(this.txtLegajo, 3, 2);
            this.tlpProfesor.Controls.Add(this.lblPlan, 2, 4);
            this.tlpProfesor.Controls.Add(this.cmbPlan, 3, 4);
            this.tlpProfesor.Controls.Add(this.txtTipoPersona, 1, 5);
            this.tlpProfesor.Controls.Add(this.cmbTipoPersona, 3, 0);
            this.tlpProfesor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tlpProfesor.Location = new System.Drawing.Point(12, 12);
            this.tlpProfesor.Name = "tlpProfesor";
            this.tlpProfesor.RowCount = 6;
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpProfesor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProfesor.Size = new System.Drawing.Size(665, 239);
            this.tlpProfesor.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(3, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(468, 208);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(335, 208);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(136, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(180, 20);
            this.txtId.TabIndex = 16;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "ID";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(468, 44);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(174, 20);
            this.txtApellido.TabIndex = 20;
            this.txtApellido.TabStop = false;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(335, 41);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 13;
            this.lblApellido.Text = "Apellido";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(335, 123);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 27;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(468, 126);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(174, 20);
            this.txtTelefono.TabIndex = 29;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(3, 82);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(91, 13);
            this.lblFechaNac.TabIndex = 35;
            this.lblFechaNac.Text = "Fecha nacimiento";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNombre.Location = new System.Drawing.Point(136, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 17;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(136, 85);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaNacimiento.TabIndex = 41;
            this.dtpFechaNacimiento.Value = new System.DateTime(2016, 8, 22, 0, 0, 0, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(335, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(136, 167);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 164);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(3, 123);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 36;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(136, 126);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(180, 20);
            this.txtDireccion.TabIndex = 37;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(335, 82);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(39, 13);
            this.lblLegajo.TabIndex = 43;
            this.lblLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(468, 85);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(174, 20);
            this.txtLegajo.TabIndex = 44;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(335, 164);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 46;
            this.lblPlan.Text = "Plan";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DataSource = this.planesBindingSource1;
            this.cmbPlan.DisplayMember = "desc_plan";
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(468, 167);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(174, 21);
            this.cmbPlan.TabIndex = 48;
            this.cmbPlan.ValueMember = "id_plan";
            // 
            // planesBindingSource1
            // 
       //     this.planesBindingSource1.DataMember = "planes";
          //  this.planesBindingSource1.DataSource = this.academia2DataSet1;
            // 
            // academia2DataSet1
            // 
          //  this.academia2DataSet1.DataSetName = "academia2DataSet1";
           // this.academia2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTipoPersona
            // 
            this.txtTipoPersona.Location = new System.Drawing.Point(136, 208);
            this.txtTipoPersona.Name = "txtTipoPersona";
            this.txtTipoPersona.Size = new System.Drawing.Size(174, 20);
            this.txtTipoPersona.TabIndex = 50;
            // 
            // tiposPersonasBindingSource
            // 
            this.tiposPersonasBindingSource.DataSource = typeof(Util.Enumeradores.TiposPersonas);
            // 
            // academia2DataSet
            // 
       //     this.academia2DataSet.DataSetName = "academia2DataSet";
      //      this.academia2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      //      // 
            // planesBindingSource
            // 
     //       this.planesBindingSource.DataMember = "planes";
   //         this.planesBindingSource.DataSource = this.academia2DataSet;
    //        // 
            // planesTableAdapter
            // 
      //      this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // planesTableAdapter1
            // 
    //        this.planesTableAdapter1.ClearBeforeFill = true;
            // 
            // cmbTipoPersona
            // 
            this.cmbTipoPersona.FormattingEnabled = true;
            this.cmbTipoPersona.Location = new System.Drawing.Point(468, 3);
            this.cmbTipoPersona.Name = "cmbTipoPersona";
            this.cmbTipoPersona.Size = new System.Drawing.Size(174, 21);
            this.cmbTipoPersona.TabIndex = 51;
            // 
            // PersonaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 252);
            this.Controls.Add(this.tlpProfesor);
            this.Name = "PersonaAlta";
            this.Text = "ProfesorAlta";
            this.Load += new System.EventHandler(this.PersonaAlta_Load);
            this.tlpProfesor.ResumeLayout(false);
            this.tlpProfesor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource1)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.academia2DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposPersonasBindingSource)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.academia2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpProfesor;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
    //    private academia2DataSet academia2DataSet;
        private System.Windows.Forms.BindingSource planesBindingSource;
    //    private academia2DataSetTableAdapters.planesTableAdapter planesTableAdapter;
   //     private academia2DataSet1 academia2DataSet1;
        private System.Windows.Forms.BindingSource planesBindingSource1;
  //      private academia2DataSet1TableAdapters.planesTableAdapter planesTableAdapter1;
        private System.Windows.Forms.BindingSource tiposPersonasBindingSource;
        private System.Windows.Forms.TextBox txtTipoPersona;
        private System.Windows.Forms.ComboBox cmbTipoPersona;

    }
}