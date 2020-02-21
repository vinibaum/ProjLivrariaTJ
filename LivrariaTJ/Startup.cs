using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LivrariaTJ.Startup))]
namespace LivrariaTJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
