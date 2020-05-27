using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GalleryApp.MVCUI.Startup))]
namespace GalleryApp.MVCUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
