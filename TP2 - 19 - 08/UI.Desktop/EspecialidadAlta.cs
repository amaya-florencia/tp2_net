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
            this.EspecialidadActual = especialidadLogic.GetOne(ID);
            this.MapearDeDatos();
        }
        #region Propiedades
        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }
        #endregion
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                
                EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text);
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;


                EspecialidadActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text);
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;

                EspecialidadActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                EspecialidadActual.State = Usuario.States.Unmodified;
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
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
                case ModoForm.Consulta:
                    this.Text = "Consulta de Especialidad";
                    btnAceptar.Text = "Aceptar";
                    break;
            }

        }
        public virtual void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic espLog = new EspecialidadLogic();
            espLog.Save(EspecialidadActual);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
 
                this.GuardarCambios();
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }
    }
}
