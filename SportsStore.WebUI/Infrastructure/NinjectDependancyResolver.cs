using Ninject;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;

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
            Mock<IProductRepository> myMock
                = new Mock<IProductRepository>();

            myMock.Setup(m => m.Products).Returns(new List<Product>()
            { 
                new Product { 
                    ProductId = 1, 
                    ProductCategory = "HelloWorld", 
                    ProductDescription = "Everyone owns it" , 
                    ProductName = "Basic", 
                    ProductPrice = 12
                },
                new Product {
                    ProductId = 2,
                    ProductCategory = "FooBar",
                    ProductDescription = "Something to cause trouble" ,
                    ProductName = "TroubleMaker",
                    ProductPrice = 12
                },
            });
            kernel.Bind<IProductRepository>().ToConstant(myMock.Object);
        }
    }
}