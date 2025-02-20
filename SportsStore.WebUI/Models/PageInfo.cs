using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }     // Total number of items
        public int ItemsPerPage { get; set; }   // Items displayed per page
        public int CurrentPage { get; set; }    // The current active page

        // Computed property: Total Pages
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        // Optional Constructor for convenience
        public PageInfo(int totalItems, int itemsPerPage, int currentPage)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
        }
    }
}