using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetStore.Domain.Entities;

namespace GadgetStore.WebUI.Models
{
    public class ProductViewListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}