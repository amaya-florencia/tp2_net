using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI_Web.Startup))]
namespace UI_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app); ///error Se produjo una excepción de tipo 'System.IO.FileLoadException'
                                ///en UI_Web.dll pero no se controló en el código del usuario
        }
    }
}
