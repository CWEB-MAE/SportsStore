using System;
using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductViewListModel
    {
        public IEnumerable<Product> Products { get; set; } // List of products
        public PageInfo PageInfo { get; set; } // Pagination details
        public string CurrentCategory { get; set; } // Currently selected category
    }
}
