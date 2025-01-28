using Ninject;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependancyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependancyResolver (IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBinding();
        }

        public object GetService(Type myserviceType) 
        { 
            return kernel.GetService(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType) 
        { 
            return kernel.GetAll(myserviceType);
        }

        private void AddBinding() 
        {
            // Put bindings here
        }
    }
}