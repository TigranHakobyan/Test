using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatTest.Startup))]
namespace FlatTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
