using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;
using Data.Database;
using Util;

namespace Data.Database
{
   public class AlumnosAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona=@tipo_persona", this.SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"]; ///id? o id_persona?
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }
                drPersonas.Close();
            }catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("error al recuperar los datos");
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@ID ", SqlConn);
                cmdPersonas.Parameters.Add("@id_persona", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"]; ///id? o id_persona?
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];


                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return per;
        }
        public void Delete(int ID)
        {
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@ID", SqlConn);
                cmdDelete.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido" +
                                                    "email=@email,direccion=@direccion, telefono=@telefono, fecha_nac=@fecha_nac"+
                                                    "legajo=@legajo, tipo_persona=@tipo_persona "+
                                                    "id_plan=@id_plan WHERE id_persona=@id_persona", SqlConn);

                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar,50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos del alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas( nombre, apellido, email, direccion, telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                                                    "VALUES(@nombre, @apellido, @email, @direccion, @telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                                                    "Select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


    }
    
}
