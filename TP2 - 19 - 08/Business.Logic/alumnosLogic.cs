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
    class AlumnosLogic:BusinessLogic
    {
        AlumnosAdapter _AlumnoData;
        public AlumnosAdapter AlumnoData
        {
            get { return _AlumnoData; }
            set { _AlumnoData = value; }
        }

        public AlumnosLogic()
        {
            AlumnosAdapter AlumnoData = new AlumnosAdapter ();

        }

        public List<Persona> GetAll()
        {
            try
            {
              AlumnosAdapter aa = new AlumnosAdapter();
                return aa.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error GetAll", Ex);
                throw ExcepcionManejada;
            }
        }

        public Persona GetOne(int id)
        {
            return AlumnoData.GetOne(id);
        }
        public void Detele(int id)
        {
            AlumnoData.Delete(id);
        }

        public void Save(Persona per)
        {
            AlumnosAdapter oAlumnosAdapter = new AlumnosAdapter();
            oAlumnosAdapter.Save(per);
        }
    }
}
