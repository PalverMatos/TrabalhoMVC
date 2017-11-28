using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRABALHOMVC.Startup))]
namespace TRABALHOMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
