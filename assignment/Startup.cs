using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(assignment.Startup))]
namespace assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
