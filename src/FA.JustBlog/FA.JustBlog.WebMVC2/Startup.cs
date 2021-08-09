using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(FA.JustBlog.WebMVC2.Startup))]
namespace FA.JustBlog.WebMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
