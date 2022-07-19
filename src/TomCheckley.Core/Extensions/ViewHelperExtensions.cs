using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TomCheckley.Core.Models.ViewModels;

namespace TomCheckley.Core.Extensions
{
    public static class ViewHelperExtensions
    {
        #region Pagination

        public static IHtmlContent Pagination(this IHtmlHelper htmlHelper, int totalResults, int currentPage, int resultsPerPage, string url)
        {
            var model = new PaginationViewModel()
            {
                CurrentPage = currentPage,
                ResultsPerPage = resultsPerPage,
                TotalResults = totalResults,
                Url = url,
            };
            return htmlHelper.Partial("ViewHelpers/Pagination", model);
        }

        #endregion Pagination
    }
}
