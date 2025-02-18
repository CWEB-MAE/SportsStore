using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository productRepository;
        public NavController (IProductRepository repo) 
        {
            productRepository = repo;            
        }
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = productRepository.Products.Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}