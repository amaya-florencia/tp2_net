using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Database;
using Business.Entities;




namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        /*
         * 
         * TP2 - Unidad 2 - Lab 03
         * 
         */
         
        UsuarioAdapter _UsuarioData;
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public UsuarioLogic()
        {
           UsuarioAdapter usrAdapter = new UsuarioAdapter();
        }
        public List<Usuario> GetAll()
        {
            try
            {
                UsuarioAdapter ua = new UsuarioAdapter();
                return ua.GetAll();
            }catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error GetAll",Ex);
                throw ExcepcionManejada;
            }
        }
        public Usuario GetOne(int id)
        {
            UsuarioAdapter ua = new UsuarioAdapter();

            return ua.GetOne(id);
        }
        public void Detele(int id)
        {
            UsuarioData.Delete(id);
        }
   
       public void Save(Usuario usr)
        {
            UsuarioAdapter oUsuarioAdapter = new UsuarioAdapter();
            oUsuarioAdapter.Save(usr);
        }

/* 

        public void Conexion()
        {
            //Instancio el constructor de UsuarioData que tiene el código de acceso la base de datos.

            UsuarioAdapter oUsuarioAdapter = new UsuarioAdapter();

        }

        public DataTable GetAll()
        {
            //Llamo al método GetAll() de Business.Entities.Usuario y guardo su resultado en el DataTable que retorno.
            UsuarioAdapter oUsuarioAdapter = new UsuarioAdapter();
            DataTable dtUsuarios = new DataTable();
            dtUsuarios = oUsuarioAdapter.GetAll();
            return dtUsuarios;
        }
        public DataTable GetOne()
        {
            UsuarioAdapter oUsuarioAdapter = new UsuarioAdapter();
            DataTable dtUsuarios = new DataTable();
            dtUsuarios = oUsuarioAdapter.GetOne();
            return dtUsuarios;
        }
        public void GuardarCambios(DataTable dtUsuarios)
        {
            //Actualizo el DataTable en Business.Entities.Usuario (CREO)
            UsuarioAdapter oUsuarioAdapter = new UsuarioAdapter();
            oUsuarioAdapter.daUsuarios.Update(dtUsuarios);
            dtUsuarios.AcceptChanges();
        }

*/

    }
}
