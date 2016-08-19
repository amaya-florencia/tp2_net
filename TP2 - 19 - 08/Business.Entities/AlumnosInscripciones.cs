using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class AlumnosInscripciones : BusinessEntity
    {
        string _Condicion;
        int _IdAlumno, _IdCurso, _Nota;
         
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public int IdAlumno
        {
            get { return _IdAlumno; }
            set { _IdAlumno = value; }
        }
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
