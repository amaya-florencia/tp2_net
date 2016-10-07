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
    public class PlanLogic : BusinessLogic
    {
        PlanAdapter PlanData = new PlanAdapter();
        public List<Plan> GetAll()
        {
            try
            {
                PlanAdapter pa = new PlanAdapter();
                return pa.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error GetAll", Ex);
                throw ExcepcionManejada;
            }
        }
        public Plan GetOne(int id)
        {
            return PlanData.GetOne(id);
        }
        
        public void Delete(int id)
        {
            PlanData.Delete(id);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
