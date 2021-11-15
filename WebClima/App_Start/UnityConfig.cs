using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebClima.Data;

namespace WebClima
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<WebClimaContext>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}