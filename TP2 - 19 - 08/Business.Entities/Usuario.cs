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
        private String _NombreUsuario, _Clave, _Nombre, _Apellido, _Email, _TipoDocumento, _NroDocumento, _Direccion, _Telefono, _Celular; 
        private bool _Habilitado;
        private DateTime _FechaNac;

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
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public bool Habilitado
        {
            get { return _Habilitado;}
            set { _Habilitado = value; }
        }

        public String TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        public String NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }

        public String Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        #endregion

    }
       
}

