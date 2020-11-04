using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnowledgeTestingSystem.Startup))]
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
