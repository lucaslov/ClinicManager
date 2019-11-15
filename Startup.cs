using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicManager.Startup))]
namespace ClinicManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
