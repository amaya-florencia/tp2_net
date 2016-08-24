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
    public class EspecialidadLogic
    {
        EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public EspecialidadLogic()
        {
            EspecialidadAdapter EspecialidadData = new EspecialidadAdapter();

        }

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
        
    }
}
