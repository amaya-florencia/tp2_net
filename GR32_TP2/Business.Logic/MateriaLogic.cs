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
    public class MateriaLogic
    {
        MateriaAdapter ma = new MateriaAdapter();  
        public List<Materia> GetAll(int idPlan)
        {
            return ma.GetAll(idPlan);
        }
        public List<Materia> GetAll()
        {
            return ma.GetAll();
        }
        public Materia GetOne(int ID)
        {
            return ma.GetOne(ID);
        }
        public void Save(Materia mat)
        {
            ma.Save(mat);
        }
        public void Delete(int ID)
        {
            ma.Delete(ID);
        }

    }
}
