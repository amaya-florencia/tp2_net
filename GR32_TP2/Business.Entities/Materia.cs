using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
  public class Materia : BusinessEntity
    {
        string _Descripcion;
        int _HsSemanales, _HsTotales, _IdPlan;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
        }
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
    }
}
