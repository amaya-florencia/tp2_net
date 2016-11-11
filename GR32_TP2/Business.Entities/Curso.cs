using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Curso : BusinessEntity
    {
        int _AnioCalendario, _Cupo, _IdComision, _IdMAteria;
        string _Descripcion;

        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value;}
        }
        public int IdMAteria
        {
            get { return _IdMAteria; }
            set { _IdMAteria = value; }
        }
    }
}
