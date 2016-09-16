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
                EspecialidadAdapter ea = new EspecialidadAdapter();
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
            EspecialidadAdapter ea = new EspecialidadAdapter();
            return ea.GetOne(ID);
        }
        public void Delete(int ID)
        {
            EspecialidadAdapter ea = new EspecialidadAdapter();
            ea.Delete(ID);
        }

        public void Save(Especialidad esp)
        {
            EspecialidadAdapter oEspecialidadAdapter = new EspecialidadAdapter();
            oEspecialidadAdapter.Save(esp);
        }
    }
}
