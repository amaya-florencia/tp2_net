using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using Data.Database;
using System.Data.SqlClient;


namespace Data.Database
{
   

    public class PlanAdapter:Adapter
    {
       
        public List<Plan> GetAll()
        {
            
            List<Plan> planes = new List<Plan>();
            try
            {               
                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes", this.SqlConn);
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
                    plan.IdEspecialidad = (int)drPlanes["id_especialidad"];
                }
            }catch{

            }
            return plan;
        }
       

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {   

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes(desc_plan,id_especialidad)" +
                                                    "VALUES(@desc_plan, @id_especialidad)" +
                                                    "Select @@identity", SqlConn);

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Plan plan)
        {
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad" +                                                
                                                " WHERE id_plan=@id", SqlConn);


            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
            cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
            cmdSave.Parameters.Add("@id_especialidad", SqlDbType.VarChar, 50).Value = plan.IdEspecialidad;
            

            cmdSave.ExecuteNonQuery();
            this.CloseConnection();
        }
        public void Delete(int ID)
        {
           
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM planes WHERE id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
