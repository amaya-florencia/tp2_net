using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class DocenteCurso : BusinessEntity
    {
        int _IdDocente, _IdCurso;
        private TiposCargos _Cargo;

        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        public TiposCargos Cargo
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public class TiposCargos
        {
        }
    }
}
