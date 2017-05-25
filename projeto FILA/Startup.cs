using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projeto_FILA.Startup))]
namespace projeto_FILA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
