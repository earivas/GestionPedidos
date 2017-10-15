using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionPedidos.Startup))]
namespace GestionPedidos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
