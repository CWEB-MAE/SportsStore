﻿using System;
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

            ProductViewListModel model = new ProductViewListModel();

            return View(myProductRepository.Products.OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo { CurrentPage = page, ItemPerPage = PageSize, TotalItem = myProductRepository.Products.Count()}
                );

            // Take() returns a sequence containing up to the specified number of items.
            // Anything after the count is ignored.
        }

        //public ViewResult List()
        //{
        //    return View(myProductRepository.Products);
        //}
    }
}