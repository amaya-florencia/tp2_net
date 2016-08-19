using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class UsuarioData
    {
        #region "SQL Adapter"
        protected SqlDataAdapter _daUsuarios;

        public SqlDataAdapter daUsuarios
        {
            get { return _daUsuarios; }
            set { _daUsuarios = value; }
        }
        #endregion


        #region "SQL Connection"
        protected SqlConnection _conn;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        #endregion

        public UsuarioData()
        {
            this.Conn = new SqlConnection("Data Source=LAPTOP-DVC8AGA3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;");
                
                //"Data Source=localhost;Initial Catalog=academia;Integrated Security=true;");
        
            /*
                Facultad:  "Data Source=localhost\\UTNFRRO;Initial Catalog=Academia;Integrated Security=false;user=net;password=net;");
                            "Data Source=serverisi;Initial Catalog=academia;Integrated Security=false;user=net;password=net;");
                Casa: "Data Source=localhost;Initial Catalog=academia;Integrated Security=true;");
                MS SQL SERVER 2005 Express Edition: "Data Source=localhost\SQLEXPRESS;Initial Catalog=academia;Integrated Security=true;");
             */



            //SELECT
            this.daUsuarios = new SqlDataAdapter("select * from usuarios",this.Conn);

            //UPDATE
            this.daUsuarios.UpdateCommand =
            new SqlCommand(" UPDATE usuarios " +
            " SET tipo_doc = @tipo_doc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
            " apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
            " telefono = @telefono, email = @email, celular = @celular, usuario = @usuario, " +
            " clave = @clave WHERE id=@id ", this.Conn);
            this.daUsuarios.UpdateCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.daUsuarios.UpdateCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.daUsuarios.UpdateCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.daUsuarios.UpdateCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.daUsuarios.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.daUsuarios.UpdateCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.daUsuarios.UpdateCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.daUsuarios.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.daUsuarios.UpdateCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.daUsuarios.UpdateCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.daUsuarios.UpdateCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");
            this.daUsuarios.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
           
            //INSERT
            this.daUsuarios.InsertCommand =
            new SqlCommand(" INSERT INTO usuarios(tipo_doc,nro_doc,fecha_nac,apellido, "+
	            " nombre,direccion,telefono,email,celular,usuario,clave) "+
	            " VALUES (@tipo_doc,@nro_doc,@fecha_nac,@apellido,@nombre,@direccion, " +
	            " @telefono,@email,@celular, @usuario, @clave  )", this.Conn);
            this.daUsuarios.InsertCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.daUsuarios.InsertCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.daUsuarios.InsertCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.daUsuarios.InsertCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.daUsuarios.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.daUsuarios.InsertCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.daUsuarios.InsertCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.daUsuarios.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.daUsuarios.InsertCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.daUsuarios.InsertCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.daUsuarios.InsertCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");


            //DELETE
            this.daUsuarios.DeleteCommand =
                            new SqlCommand(" DELETE FROM usuarios WHERE id=@id ", this.Conn);
            this.daUsuarios.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
        }

        public DataTable GetAll()
        {
            DataTable dtUsuarios = new DataTable();
            this.daUsuarios.Fill(dtUsuarios);
            return dtUsuarios;
        }


        public void GuardarCambios(DataTable dtUsuarios)
        {
            this.daUsuarios.Update(dtUsuarios);
            dtUsuarios.AcceptChanges();
        }
        public DataTable GetOne()
        {
           DataTable dtUsuarios=new DataTable();
           this.daUsuarios.Fill(dtUsuarios);
           return dtUsuarios;
        }

        public void Save(Usuario usr)
        {
            ///////////////////////////////

        }

    } //End Class


}//End Namespace
