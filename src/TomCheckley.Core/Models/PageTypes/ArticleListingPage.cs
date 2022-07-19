using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.PageTypes.Base;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ArticleListingPage : ModularPage
    {
        public PaginatedArticleCardsList Items { get; internal set; }

        public ArticleListingPage(IPublishedContent content) : base(content)
        {
        }
    }
}
