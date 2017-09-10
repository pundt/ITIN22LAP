using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoggingDemo.Startup))]
namespace LoggingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
