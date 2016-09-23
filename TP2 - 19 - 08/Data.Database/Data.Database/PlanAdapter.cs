using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using Data.Database;
using System.Data.SqlClient;


namespace Data.Database
{
    class PlanAdapter:Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {               
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("SELECT * FROM planes", this.SqlConn);
                SqlDataReader drPlan = cmdPlan.ExecuteReader();
                while (drPlan.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    plan.IdEspecialidad = (int)drPlan["id_especialidad"];
                    planes.Add(plan);
                }
                drPlan.Close();
            }catch(Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", ex);                
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                }
            }catch{

            }
            return plan;
        }
        
    }
}
