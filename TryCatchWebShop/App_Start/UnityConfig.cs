using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using TryCatch.Lib.BLL;
using System.Web;
using System.Configuration;

namespace TryCatch.Web.Shop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var fullPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductsXmlFileLocation"]);
            container.RegisterType<IProductsBLL>(new InjectionFactory(c => new ProductsBLL(fullPath)));

            container.RegisterType<IOrdersBLL, OrdersBLL>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}