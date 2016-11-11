using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class AlumnosInscripcionesLogic
    {
        AlumnosInscripcionesAdapter _AlumInscData;

        public AlumnosInscripcionesAdapter AlumInscData
        {
            get { return _AlumInscData; }
            set { _AlumInscData = value; }
        }

        #region Constructores
        public AlumnosInscripcionesLogic()
        {
            AlumnosInscripcionesAdapter ComisionData = new AlumnosInscripcionesAdapter();
        }
        #endregion



    }

}
