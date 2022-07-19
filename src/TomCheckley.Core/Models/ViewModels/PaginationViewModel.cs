using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Extensions;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ViewModels
{
    public class PaginationViewModel
    {
        public virtual int TotalResults { get; set; }
        public virtual int CurrentPage { get; set; }
        public virtual int ResultsPerPage { get; set; }

        public virtual int ResultsFrom
        { get { return ((CurrentPage - 1) * ResultsPerPage) + 1; } } // 1 - 1 = 0 * 10 = 0 + 1 === 1 // 5 - 1 = 4 * 10 = 40 + 1 === 41

        public virtual int ResultsTo
        { get { return Math.Min(CurrentPage * ResultsPerPage, TotalResults); } }   // 1 * 10 === 10 // 5 * 10 === 50

        public virtual int TotalPages
        { get { return TotalResults <= 0 ? 0 : Convert.ToInt32(Math.Ceiling(TotalResults / Convert.ToSingle(ResultsPerPage))); } }    // 3 / 10.0 = 0.3 (rounded up) = 1

        public virtual string Url { get; set; }

        public virtual string GetPageUrl(int page)
        {
            if (Url.IsNullOrWhiteSpace()) { throw new NullReferenceException("PaginatedUrl is null and needs to be set in order for the page URL to be generated"); }
            return Url.UpdateQueryStringValue("page", page.ToString());
        }
    }
}
