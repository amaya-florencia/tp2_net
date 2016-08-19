using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public  class Comision : BusinessEntity
    { 
        int _AnioEspecialidad, _IdPlan;
        string _Descripcion;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
    }
}
