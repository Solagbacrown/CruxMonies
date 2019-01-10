using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CruxMonies.Startup))]
namespace CruxMonies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
