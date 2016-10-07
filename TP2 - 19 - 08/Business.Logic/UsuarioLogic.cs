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
        #region Constructores
        public UsuarioLogic()
        {
            UsuarioAdapter UsuarioData = new UsuarioAdapter();
        }
        #endregion
        UsuarioAdapter UsuarioData = new UsuarioAdapter();
        public List<Usuario> GetAll()
        { 
                UsuarioAdapter ua = new UsuarioAdapter();
                return ua.GetAll();
        }
        public Usuario GetOne(int id)
        {            
            return UsuarioData.GetOne(id);
        }
        public Usuario GetOne(string nombreUsuario, string pass)
        {
            Usuario u = UsuarioData.GetOne(nombreUsuario);
            if (u.Clave != pass)
            {
                u = null;
            }
            return u;
        }
        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }
   
       public void Save(Usuario usr)
        {            
            UsuarioData.Save(usr);
        }
    }
}
