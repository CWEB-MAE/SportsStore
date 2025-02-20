using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PageInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int totalPages = pagingInfo.TotalPages;
            int currentPage = pagingInfo.CurrentPage;
            int adjacentPages = 2; // Number of pages to show before and after the current page

            // Determine the range of pages to display
            int startPage = Math.Max(1, currentPage - adjacentPages);
            int endPage = Math.Min(totalPages, currentPage + adjacentPages);

            // If the start page is greater than 1, show the first page and an ellipsis if necessary.
            if (startPage > 1)
            {
                TagBuilder firstTag = new TagBuilder("a");
                firstTag.MergeAttribute("href", pageUrl(1));
                firstTag.InnerHtml = "1";
                firstTag.AddCssClass("btn btn-default");
                if (1 == currentPage)
                {
                    firstTag.AddCssClass("selected btn-primary");
                }
                result.Append(firstTag.ToString());

                if (startPage > 2)
                {
                    result.Append("<span class='btn btn-default'>...</span>");
                }
            }

            // Generate page links for the determined range
            for (int i = startPage; i <= endPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tag.AddCssClass("btn btn-default");
                if (i == currentPage)
                {
                    tag.AddCssClass("selected btn-primary");
                }
                result.Append(tag.ToString());
            }

            // If the end page is less than the total pages, add an ellipsis and a link to the last page.
            if (endPage < totalPages)
            {
                if (endPage < totalPages - 1)
                {
                    result.Append("<span class='btn btn-default'>...</span>");
                }
                TagBuilder lastTag = new TagBuilder("a");
                lastTag.MergeAttribute("href", pageUrl(totalPages));
                lastTag.InnerHtml = totalPages.ToString();
                lastTag.AddCssClass("btn btn-default");
                if (totalPages == currentPage)
                {
                    lastTag.AddCssClass("selected btn-primary");
                }
                result.Append(lastTag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}
