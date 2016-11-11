using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities 
{
   public  class Modulo : BusinessEntity
    {
        string _Descripcion;
        private string _ejecuta;

        public  string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Ejecuta
        {
            get { return _ejecuta; }
            set { _ejecuta = value; }
        }
    }
}
