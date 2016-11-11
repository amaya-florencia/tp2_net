using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using Data.Database;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
           else if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }

        }
        public List<Materia> GetAll(int idPlan)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_plan=@idPlan");
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = idPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex )
            {
                Exception ExcepcionManejada = new Exception("Error al intentarrecuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;

        } 
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias",this.SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentarrecuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;

        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id",this.SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                   
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentarrecuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;

        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia,hs_semanales,hs_totales,id_plan) VALUES" +
                "(@desc,@hsSemanales,@hsTotales,@id_plan)" + " SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hsSemanales",SqlDbType.Int, 50).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@hsTotales", SqlDbType.Int, 50).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = mat.IdPlan;
                mat.ID = Convert.ToInt32(cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar guardar materia " + mat.Descripcion, ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Update(Materia mat)
        {

            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia=@desc,hs_semanales=@hsSemanales,hs_totales=@hsTotales, id_plan=@idPlan" +
                                                    " WHERE id_materia=@id", this.SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int, 50).Value = mat.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mat.Descripcion ;
                cmdSave.Parameters.Add("@hsSemanales", SqlDbType.Int, 50).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@hsTotales", SqlDbType.Int, 50).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int, 50).Value = mat.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar materia" + mat.Descripcion , Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
