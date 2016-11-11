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
    public partial class EspecialidadAlta : ApplicationForm
    {
        #region Constructores

        public EspecialidadAlta()
        {
            InitializeComponent();
        }
        public EspecialidadAlta(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public EspecialidadAlta(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            try
            {
                this.EspecialidadActual = especialidadLogic.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
       
        #region Propiedades
        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }
        #endregion

        #region Metodos
        public override void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {               
                EspecialidadActual = new Especialidad();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;                
            }            
            switch (this.Modo)
            {
                case ApplicationForm.ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                case ApplicationForm.ModoForm.Baja:
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
            }

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Especialidad";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.txtDescripcion.ReadOnly = true;
                    this.Text = "Baja de Especialidad";
                    btnAceptar.Text = "Eliminar";
                    break;                
            }
        }
        public override void GuardarCambios()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {              
                this.MapearADatos();               
                especialidadLogic.Save(EspecialidadActual);
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                try
                {
                    especialidadLogic.Delete(EspecialidadActual.ID);
                }
                catch (Exception ex)
                {
                    this.Notificar(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Eventos

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                DialogResult rta = MessageBox.Show("Confirma la eliminacion de la especialidad" + this.EspecialidadActual.Descripcion + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
