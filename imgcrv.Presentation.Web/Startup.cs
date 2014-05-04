using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(imgcrv.Presentation.Web.Startup))]
namespace imgcrv.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
