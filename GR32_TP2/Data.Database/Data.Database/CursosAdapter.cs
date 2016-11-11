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
    public class CursosAdapter : Adapter
    {
        public void Save(Curso cur)
        {
            if (cur.State == BusinessEntity.States.New)
            {
                this.Insert(cur);
            }
            else if (cur.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cur.ID);
            }
            else if (cur.State == BusinessEntity.States.Modified)
            {
                this.Update(cur);
            }

        }
        #region Metodos get
        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["descripcion"];
                    curso.IdComision = (int)drCursos["id_curso"];
                    curso.IdMAteria = (int)drCursos["id_materia"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                }
            }
            catch
            {

            }
            return curso;
        }
        public List<Curso> GetAll()
        {

            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", this.SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IdComision = (int)drCursos["id_comision"];
                    curso.IdMAteria = (int)drCursos["id_materia"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(curso);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;

        }
        #endregion

        #region Transacciones
        protected void Insert(Curso cur)
        {
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(anio_calendario,cupo,id_comision,id_materia,descripcion) VALUES" +
                "(@anio,@cupo,@id_comision,@id_materia,@desc)" + " SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@anio", SqlDbType.VarChar, 50).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int, 50).Value = cur.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int, 50).Value = cur.IdComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int, 50).Value = cur.IdMAteria;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = cur.Descripcion;
                cur.ID = Convert.ToInt32(cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar guardar curso " + cur.Descripcion, ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET anio_calendario=@anio,cupo=@cupo,id_comision=@id_comision,id_materia=@id_materia,descripcion=@descripcion" +
                                                    " WHERE id_curso=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int, 50).Value = curso.ID;
                cmdSave.Parameters.Add("@anio", SqlDbType.VarChar, 50).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int, 50).Value = curso.IdComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int, 50).Value = curso.IdMAteria;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;

                cmdSave.ExecuteNonQuery();
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar guardar curso:  " + curso.Descripcion, Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int, 50).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        #endregion
    }
}
