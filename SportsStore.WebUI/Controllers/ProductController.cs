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

        public ProductController(IProductRepository productRepository) 
        { 
            this.myProductRepository = productRepository;
        }

        // GET: Product
        public int PageSize = 4;

        public ViewResult List(int page = 1)
        {
            // Skip(int) - Ignores the specified number of items
            // and returns a sequence starting at the item after the
            // last skipped item (if any).

            ProductViewListModel model = new ProductViewListModel
            {
                Products = myProductRepository.Products.OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                pageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItem = myProductRepository.Products.Count()
                }
            };

            return View(model);
        }

        //public ViewResult List()
        //{
        //    return View(myProductRepository.Products);
        //}
    }
}