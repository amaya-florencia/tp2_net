using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll(int idUsuario)
        {
            List<ModuloUsuario> modulosUsuario = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM modulos_usuarios mu " +
                    "INNER JOIN modulos m ON m.id_modulo = mu.id_modulo " +
                    "WHERE mu.id_usuario = @id_usuario",
                    this.SqlConn);
                cmdGetAll.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario moduloUsuario = new ModuloUsuario();
                    moduloUsuario.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    moduloUsuario.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    moduloUsuario.PermiteAlta = drModulosUsuarios.IsDBNull(3) ? false : (bool)drModulosUsuarios["alta"];
                    moduloUsuario.PermiteBaja = drModulosUsuarios.IsDBNull(4) ? false : (bool)drModulosUsuarios["baja"];
                    moduloUsuario.PermiteModificacion = drModulosUsuarios.IsDBNull(5) ? false : (bool)drModulosUsuarios["modificacion"];
                    moduloUsuario.PermiteConsulta = drModulosUsuarios.IsDBNull(6) ? false : (bool)drModulosUsuarios["consulta"];
                    moduloUsuario.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    moduloUsuario.Modulo.Descripcion = drModulosUsuarios["desc_modulo"].ToString();
                    modulosUsuario.Add(moduloUsuario);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar datos de los permisos.", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosUsuario;
        }

        public ModuloUsuario GetOne(int idModuloUsuario)
        {
            ModuloUsuario moduloUsuario = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM modulos_usuarios mu" +
                    " INNER JOIN modulos m ON m.id_modulo = mu.id_modulo" +
                    " WHERE mu.id_modulo_usuario = @id_modulo_usuario",
                    this.SqlConn);
                cmdGetOne.Parameters.Add("@id_modulo_usuario", SqlDbType.Int).Value = idModuloUsuario;
                SqlDataReader drModulosUsuarios = cmdGetOne.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    moduloUsuario.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    moduloUsuario.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    moduloUsuario.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    moduloUsuario.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    moduloUsuario.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    moduloUsuario.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    moduloUsuario.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    moduloUsuario.Modulo.Descripcion = drModulosUsuarios["desc_modulo"].ToString();
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar datos del módulo para un usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return moduloUsuario;
        }

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @id_modulo, " +
                                        "id_usuario = @id_usuario, alta = @alta , baja = @baja, modificacion = @modificacion, " +
                                        "consulta = @consulta " +
                                        "WHERE id_modulo_usuario = @id", this.SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.ID;
                cmdUpdate.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.Modulo.ID;
                cmdUpdate.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdUpdate.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdUpdate.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar modificar datos de permiso para un usuario.", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta) " +
                                        "VALUES(@id_modulo,@id_usuario,@alta,@baja,@modificacion,@consulta)" +
                                        "SELECT @@identity", this.SqlConn);
                cmdInsert.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.Modulo.ID;
                cmdInsert.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdInsert.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdInsert.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                moduloUsuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear permiso para un usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int idModuloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE modulos_usuarios WHERE id_modulo_usuario = @id_modulo_usuario",
                    this.SqlConn);
                cmdDelete.Parameters.Add("@id_modulo_usuario", SqlDbType.Int).Value = idModuloUsuario;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar el permiso para un usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntity.States.New)
            {
                this.Insert(moduloUsuario);
            }
            else if (moduloUsuario.State == BusinessEntity.States.Modified)
            {
                this.Update(moduloUsuario);
            }
            moduloUsuario.State = BusinessEntity.States.Unmodified;
        }

        /// <summary>
        /// Borra todos los permisos asociados a un usuario
        /// </summary>
        /// <param name="idUsuario">ID del Usuario</param>
        internal void DeleteAll(int idUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE modulos_usuarios WHERE id_usuario = @id_usuario",
                    this.SqlConn);
                cmdDelete.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar los permisos para el usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetAllTabla(int idUsuario)
        {
            DataTable dtModulosUsuario = new DataTable("ModulosUsuario");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT mu.*, m.id_modulo, m.desc_modulo FROM modulos_usuarios mu " +
                    "INNER JOIN modulos m ON m.id_modulo = mu.id_modulo " +
                    "WHERE mu.id_usuario = @id_usuario",
                    this.SqlConn);
                cmdGetAll.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                dtModulosUsuario.Load(drModulosUsuarios);

                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar datos de los permisos.", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return dtModulosUsuario;
        }
    }
}