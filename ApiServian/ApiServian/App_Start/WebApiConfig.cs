using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LOGNEGOCIO.Interfaces;
using LOGNEGOCIO.Services;
using ENTIDADES.Entities.ActionPlanBE;
using ACDATOS.Repositories;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Dependencies;

namespace ApiServian
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            //Usuario
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionUsuarioRepository, ActionUsuarioRepository>(new HierarchicalLifetimeManager());

            // Web API configuration and services
            config.DependencyResolver = new UnityResolver(container);
            // Configuración y servicios de API web

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
