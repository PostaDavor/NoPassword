using Microsoft.Owin;
using Owin;
using Presentation;

namespace Presentation
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}