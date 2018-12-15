using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBlogMVC.Startup))]
namespace MyBlogMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
