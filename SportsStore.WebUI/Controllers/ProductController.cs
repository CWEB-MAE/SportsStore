using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myProductRepository;
        public int PageSize = 2;

        public ProductController(IProductRepository productRepository)
        {
            this.myProductRepository = productRepository;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            int totalItems = category == null
                ? myProductRepository.Products.Count()
                : myProductRepository.Products.Count(p => p.Category == category);

            ProductViewListModel model = new ProductViewListModel
            {
                Products = myProductRepository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PageInfo = new PageInfo(totalItems, PageSize, page), // Using the constructor

                CurrentCategory = category
            };

            return View(model);
        }
    }
}
