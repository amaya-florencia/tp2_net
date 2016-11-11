using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        public ModuloUsuarioAdapter ModuloUsuarioData { get; set; }

        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new ModuloUsuarioAdapter();
        }

        public List<ModuloUsuario> GetAll(int idUsuario)
        {
            return ModuloUsuarioData.GetAll(idUsuario);
        }

        public ModuloUsuario GetOne(int idModuloUsuario)
        {
            return ModuloUsuarioData.GetOne(idModuloUsuario);
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            ModuloUsuarioData.Save(moduloUsuario);
        }

        public void Delete(int idModuloUsuario)
        {
            ModuloUsuarioData.Delete(idModuloUsuario);
        }

        public DataTable GetAllTabla(int idUsuario)
        {
            return ModuloUsuarioData.GetAllTabla(idUsuario);
        }
    }
}
