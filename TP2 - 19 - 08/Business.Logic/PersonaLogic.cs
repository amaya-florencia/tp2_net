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
    public class PersonaLogic : BusinessLogic
    {
        PersonaAdapter _PersonaData;
       /* public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }*/

        public PersonaLogic()
        {
            
        }

        PersonaAdapter PersonaData = new PersonaAdapter();
        public List<Persona> GetAll(Enum tipoPersona)
        {
            try
            {
                PersonaAdapter pa = new PersonaAdapter();
                return pa.GetAll(tipoPersona);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de personas.", Ex);
                throw ExcepcionManejada;
            }
        }
        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }
        public void Detele(int id)
        {
            PersonaData.Delete(id);
        }

        public void Save(Persona per)
        {
            PersonaData.Save(per);
        }
    }
}
