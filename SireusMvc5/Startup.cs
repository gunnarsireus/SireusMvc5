using Microsoft.Owin;
using Owin;
using SireusMvc5;

[assembly: OwinStartup(typeof (Startup))]

namespace SireusMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}