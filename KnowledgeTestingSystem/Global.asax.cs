using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KnowledgeTestingSystem.BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace KnowledgeTestingSystem
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //dependency injection
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}