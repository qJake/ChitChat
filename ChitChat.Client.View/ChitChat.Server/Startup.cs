using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChitChat.Server.Startup))]

namespace ChitChat.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
