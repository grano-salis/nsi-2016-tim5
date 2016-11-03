using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NSICollections.Startup))]
namespace NSICollections
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
