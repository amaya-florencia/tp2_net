using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using Data.Database;
using System.Data.SqlClient;



namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        #region 
        {
            List<Usuario> usuarios = new List<Usuario>();
            try {
                this.OpenConnection();

                
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", this.SqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];

                    usuarios.Add(usr);
                }

                    drUsuarios.Close();
                }catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            

            return usuarios;
        }
        #endregion
        public Usuario GetOne(string nombreUsu)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @nombreUsu", SqlConn);
                cmdUsuarios.Parameters.Add("@nombreUsu", SqlDbType.VarChar, 50).Value = nombreUsu;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = drUsuarios["nombre_usuario"].ToString();
                    usr.Clave = drUsuarios["clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = drUsuarios["nombre"].ToString();
                    usr.Apellido = drUsuarios["apellido"].ToString();
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        public Usuario GetOne(int ID)
        {            
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from Usuarios where id_usuario=@id ", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = drUsuarios["nombre_usuario"].ToString();
                    usr.Clave = drUsuarios["clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = drUsuarios["nombre"].ToString();
                    usr.Apellido = drUsuarios["apellido"].ToString();
                                 
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }         
             return usr;
        }
        public void Delete(int ID)
        {
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM usuarios WHERE id_usuario=@id",SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }

        protected void Update(Usuario usuario)
        {
            
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave," +
                                                "habilitado=@habilitado, nombre=@nombre, apellido=@apellido " +
                                                "WHERE id_usuario=@id", SqlConn);


            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
            cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
            cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
            cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
            
        
            cmdSave.ExecuteNonQuery();
            this.CloseConnection();
        } 

        protected void Insert(Usuario usuario)
        {
            try
            {   
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios(nombre_usuario, clave, habilitado, nombre, apellido)" +
                                                    "VALUES(@nombre_usuario, @clave, @habilitado, @nombre, @apellido)" +
                                                    "Select @@identity", SqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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

    }
}
