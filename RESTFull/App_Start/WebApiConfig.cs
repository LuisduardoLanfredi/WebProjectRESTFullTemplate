using System.Web.Http;
using Data;
using Model;
using RESTFull.App_Start;

namespace RESTFull
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            StructuremapWebApi.Start();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
