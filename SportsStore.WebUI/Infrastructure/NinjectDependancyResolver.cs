using Ninject;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Concrete;

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

            //kernel.Bind<IProductRepository>().To<EFProductRepository>();

            Mock<IProductRepository> myMock
                = new Mock<IProductRepository>();
            myMock.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product {
                    ProductID = 1,
                    Category = "GPU",
                    Brand = "Nvidia",
                    Description = "An Nvidia GPU" ,
                    Name = "RTX 5090",
                    Price = 2000
                },
                new Product {
                    ProductID = 1,
                    Category = "GPU",
                    Brand = "Nvidia",
                    Description = "An Nvidia GPU" ,
                    Name = "RTX 4090",
                    Price = 1500
                },
                new Product {
                    ProductID = 1,
                    Category = "CPU",
                    Brand = "AMD",
                    Description = "An AMD CPU" ,
                    Name = "Ryzen 7 9800X3D",
                    Price = 12
                },
            });
            kernel.Bind<IProductRepository>().ToConstant(myMock.Object);
        }
    }
}