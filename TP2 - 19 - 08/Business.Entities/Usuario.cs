using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
     public  class Usuario : BusinessEntity
    {
        #region "Propiedades"

        private Int32 _idPersona;
        private String _NombreUsuario, _Clave, _Nombre, _Apellido; 
        private bool _Habilitado;
        private List<ModuloUsuario> _modulosUsuario;

        public Int32 IdPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }
        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
     
        public bool Habilitado
        {
            get { return _Habilitado;}
            set { _Habilitado = value; }
        }
                
        public List<ModuloUsuario> ModulosUsuario
        {
            get { return _modulosUsuario; }
            set { _modulosUsuario = value; }
        }
        #endregion

    }
       
}

