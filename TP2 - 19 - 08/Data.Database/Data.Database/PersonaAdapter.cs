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
    public class PersonaAdapter : Adapter
    {
        static public Enum tipoPersona;
       public List<Persona> GetAll(Enum tipoPersona)
       // public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                int tipoPer = tipoPersona.GetHashCode();
                this.OpenConnection();

                SqlCommand cmdGetAllPersonas = new SqlCommand("select * from personas where tipo_persona=@tipo_persona", this.SqlConn);
                cmdGetAllPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = tipoPer;  

                SqlDataReader drPersonas = cmdGetAllPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];                    
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Util.Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                   /* per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    */

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
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
            //return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
            Persona per = new Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdGetOnePersona = new SqlCommand("select * from Personas where id_persona=@id ", SqlConn);
                cmdGetOnePersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdGetOnePersona.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_personas"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Util.Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la persona.", Ex);
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
            //Usuarios.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion" +
                                                    "email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo" +
                                                    "tipo_persona=@tipo_persona, id_plan=@id_plan WHERE id_usuario=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.VarChar, 50).Value = persona.TipoPersona.GetHashCode();
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = persona.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos de la persona.", Ex);
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
                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas(nombre, apellido, direccion, email, telefono, legajo, tipo_persona, id_plan)" +
                                                    "VALUES(@nombre, @apellido, @direccion, @email, @telefono, @legajo, @tipo_persona, @id_plan)" +
                                                    "Select @@identity", SqlConn);

              //  cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.VarChar, 50).Value = tipoPersona.GetHashCode(); //asigno el valor de la variable static ¿?
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = persona.IdPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la persona.", Ex);
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
    }
}
