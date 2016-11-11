using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        //Clave por defecto a utlizar para la cadena de conexion
        //const string consKeyDefaultCnnString = "ConnStringLocal";
        const string consKeyDefaultCnnString = "ConnStringFlor";

        private SqlConnection sqlConn;
        public SqlConnection SqlConn
            { get { return sqlConn; }
              set { sqlConn = value; }
            }

        protected void OpenConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(conString);
            SqlConn.Open();

        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

    }
}
