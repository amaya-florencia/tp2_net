using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Database;
using Business.Entities;


namespace Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        #region Propiedades
        EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }
        EspecialidadAdapter ea = new EspecialidadAdapter();

        #endregion

        #region Constructores
        public EspecialidadLogic()
        {
            EspecialidadAdapter EspecialidadData = new EspecialidadAdapter();
        }
        #endregion

        public List<Especialidad> GetAll()
        {
            try
            {
                return ea.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error GetAll", Ex);
                throw ExcepcionManejada;
            }
        }
        public Especialidad GetOne (int ID)
        {
            return ea.GetOne(ID);
        }
        public Especialidad GetIdEspecialidadPorDescripcion(String descripcion)
        {
            return ea.GetIdEspecialidadPorDescripcion(descripcion);
        }
        public void Delete(int ID)
        { 
            ea.Delete(ID);
        }

        public void Save(Especialidad esp)
        {
            ea.Save(esp);
        }
    }
}
