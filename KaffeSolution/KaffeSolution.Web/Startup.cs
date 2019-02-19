using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaffeSolution.Web.Startup))]
namespace KaffeSolution.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
