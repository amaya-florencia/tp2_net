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
using Util;


namespace UI.Desktop
{
    public partial class CursosAlta : ApplicationForm
    {
        #region Constructores
        public CursosAlta()
        {
            InitializeComponent();
            try
            {
                CargarCombos();
            }
            catch (Exception e )
            {
                this.Notificar("Especialidades", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public CursosAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public CursosAlta(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursosLogic cl = new CursosLogic();
            try
            {
                this.CursoActual = cl.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Propiedades
        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        #endregion

        #region Metodos

     
        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                CursoActual = new Curso();
            }
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {  
                CursoActual.IdMAteria = (int)this.cmbMaterias.SelectedValue;
                CursoActual.IdComision = (int)(this.cmbComisiones.SelectedValue);
                CursoActual.AnioCalendario = Convert.ToInt32(this.udAnio.Value);
                CursoActual.Cupo = Convert.ToInt32(this.udCupo.Value);
                CursoActual.Descripcion = this.txtDescripcion.Text;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }

        }

        public override void MapearDeDatos()
        {
            this.txtIDCurso.Text = this.CursoActual.ID.ToString();
            this.cmbMaterias.SelectedValue = this.CursoActual.IdMAteria;
            this.cmbComisiones.SelectedValue = this.CursoActual.IdComision;
            this.udAnio.Value = this.CursoActual.AnioCalendario;
            this.udCupo.Value = this.CursoActual.Cupo;
            this.txtDescripcion.Text = this.CursoActual.Descripcion.ToString();

            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Curso";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.txtDescripcion.ReadOnly = true;
                    this.Text = "Baja de Curso";
                    btnAceptar.Text = "Eliminar";
                    break;
            }
        }
        public override void GuardarCambios()
        {
            CursosLogic cursoLogic = new CursosLogic();
            if ((this.Modo == ApplicationForm.ModoForm.Alta) || (this.Modo == ApplicationForm.ModoForm.Modificacion))
            {
                try
                {
                    this.MapearADatos();
                    cursoLogic.Save(this.CursoActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    cursoLogic.Save(this.CursoActual);
                    this.Close();
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void CargarCombos()
        {
            MateriaLogic ml = new MateriaLogic();
            cmbMaterias.DataSource = ml.GetAll();
            cmbMaterias.DisplayMember = "Descripcion";
            cmbMaterias.ValueMember = "Id";
            ComisionLogic cl = new ComisionLogic();
            cmbComisiones.DataSource = cl.GetAll();
            cmbComisiones.DisplayMember = "Descripcion";
            cmbComisiones.ValueMember = "Id";
        }


        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminacion del Curso: " + this.CursoActual.Descripcion + " ?", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.OK)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
