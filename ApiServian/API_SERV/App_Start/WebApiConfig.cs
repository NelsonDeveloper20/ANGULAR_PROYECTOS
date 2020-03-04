using ACDATOS.Repositories;
using ENTIDADES.Entities.ActionPlanBE;
using FILA.SC.RestApi;
using LOGNEGOCIO.Interfaces;
using LOGNEGOCIO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace API_SERV
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var container = new UnityContainer();
             
            //Usuario
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionUsuarioRepository, ActionUsuarioRepository>(new HierarchicalLifetimeManager());

            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
