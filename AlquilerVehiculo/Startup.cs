using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlquilerVehiculo.Startup))]
namespace AlquilerVehiculo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
