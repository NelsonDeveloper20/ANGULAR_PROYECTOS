using ACDATOS.Repositories;
using ENTIDADES.Entities.ActionPlanBE;
using LOGNEGOCIO.Interfaces;
using LOGNEGOCIO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace RESP_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var container = new UnityContainer();
            // Rutas de API web
            config.MapHttpAttributeRoutes();
            //Usuario
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionUsuarioRepository, ActionUsuarioRepository>(new HierarchicalLifetimeManager());

            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
