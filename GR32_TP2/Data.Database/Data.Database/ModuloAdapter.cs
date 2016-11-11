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
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM modulos", this.SqlConn);
                SqlDataReader drModulos = cmdGetAll.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];
                    mod.Ejecuta = (string)drModulos["ejecuta"];

                    modulos.Add(mod);
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Módulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }

        public Modulo GetOne(string descripcionModulo)
        {
            Modulo modulo = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM modulos " +
                    "WHERE desc_modulo = @desc",
                    this.SqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = descripcionModulo;
                SqlDataReader drModulos = cmdGetOne.ExecuteReader();

                while (drModulos.Read())
                {
                    modulo.ID = (int)drModulos["id_modulo"];
                    modulo.Descripcion = drModulos["desc_modulo"].ToString();
                    modulo.Ejecuta = drModulos["ejecuta"].ToString();
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar datos del Módulo " + descripcionModulo, e);
            }
            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }
    }
}
