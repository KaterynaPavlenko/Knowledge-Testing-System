using KnowledgeTestingSystem;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace KnowledgeTestingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}