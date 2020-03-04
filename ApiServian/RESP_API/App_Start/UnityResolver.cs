using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace RESP_API
{
    internal class UnityResolver : IDependencyResolver
    {
        private UnityContainer container;

        public UnityResolver(UnityContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}