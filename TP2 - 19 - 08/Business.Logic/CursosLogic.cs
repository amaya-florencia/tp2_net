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
    public class CursosLogic : BusinessLogic
    {
        public CursosLogic()
        {
            CursosAdapter CursoData = new CursosAdapter();
        }

        CursosAdapter CursoData = new CursosAdapter();
        public List<Curso> GetAll()
        {
            CursosAdapter ca = new CursosAdapter();
            return ca.GetAll();
        }
        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }
        public void Delete(int id)
        {
            CursoData.Delete(id);
        }
    }
}
