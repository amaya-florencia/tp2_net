using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace IU.Consola
{
    public class Usuarios
    {
        /*
        UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioLogic _UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            UsuarioLogic usrLogic = new UsuarioLogic();

            Console.WriteLine(" 1- Listado General \n 2- Consulta \n 3- Agregar \n 4- Modificar \n 5-Eliminar \n 6-Salir");
            ConsoleKeyInfo op = Console.ReadKey();
            switch (op.Key)
            {
                case ConsoleKey.D1:
                    this.ListadoGeneral();
                    break;

                case ConsoleKey.D2:
                    this.Consultar();
                    break;

                case ConsoleKey.D3:
                    this.Agregar();

                    break;

                case ConsoleKey.D4:
                    this.Modificar();
                    break;

                case ConsoleKey.D5:
                    this.Eliminar();
                    break;

            } //end switch
        }
            public void ListaGeneral()
        {
            Console.Clear();
            foreach (Business.Entities.Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }

        }
            public void MostrarDatos(Business.Logic.Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0} ", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0} ", usr.Apellido);
            Console.WriteLine("\t\tNombreUsuario: {0} ", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0} ", usr.Clave);
            Console.WriteLine("\t\tEmail: {0} ", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0} ", usr.Habilitado);
            Console.WriteLine();
        }

        private void Agregar()
        {
            Usuario usr = new Usuario();
            Console.WriteLine("Ingrese nombre de usuario.");
            usr.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave.");
            usr.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese nombre.");
            usr.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido.");
            usr.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese email.");
            usr.Email = Console.ReadLine();
            Console.WriteLine("¿Está habilitado? 1.Sí 2.No");
            int hab = Convert.ToInt32(Console.ReadKey());
            if (hab == 1)
            {
                usr.Habilitado = true;
            }
            else
            {
                usr.Habilitado = false;
            }
            usr.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usr);
        }
        private void Consultar()
        {
            try
            {
                Console.WriteLine("Ingrese ID a buscar.");
                int id = Convert.ToInt32(Console.ReadLine());
                UsuarioNegocio.GetOne(id);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\n La Id ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void Modificar()
        {
            try {
                Usuario usr = new Usuario();
                Console.WriteLine("Ingrese nombre de usuario.");
                usr.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave.");
                usr.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese nombre.");
                usr.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido.");
                usr.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese email.");
                usr.Email = Console.ReadLine();
                Console.WriteLine("¿Está habilitado? 1.Sí 2.No");
                int hab = Convert.ToInt32(Console.ReadKey());
                if (hab == 1)
                {
                    usr.Habilitado = true;
                }
                else
                {
                    usr.Habilitado = false;
                }
                usr.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usr);
               }
             catch (FormatException fe)
            {
                Console.WriteLine("\n La Id ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void ListadoGeneral()
        {
            UsuarioNegocio.GetAll();
        }
        private void Eliminar()
        {
            try {
                Usuario usr = new Usuario();
                Console.WriteLine("Ingrese ID a eliminar.");
                int id = Convert.ToInt32(Console.ReadLine());
                UsuarioNegocio.Detele(id);
                usr.State = BusinessEntity.States.Deleted;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\n La Id ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
   */

    }//End Class

}//End Namespace
