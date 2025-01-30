using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository myProductRepository;

        public ProductController(IProductRepository productRepository) 
        { 
            this.myProductRepository = productRepository;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(myProductRepository.Products);
        }
    }
}