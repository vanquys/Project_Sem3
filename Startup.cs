using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Sem3.Startup))]
namespace Project_Sem3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
