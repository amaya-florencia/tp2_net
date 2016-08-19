using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
  public   class Plan : BusinessEntity
    {
        string _Descripcion;
        int _IdEspecialidad;

        public string Descripcion
        {
            get { return _Descripcion;}
            set { _Descripcion = value; }
        }
        public int IdEspecialidad
        {
            get { return _IdEspecialidad; }
            set { _IdEspecialidad = value; }
        }
    }
}
