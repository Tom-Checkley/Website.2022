using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Cards;
using TomCheckley.Core.Models.PageTypes;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace TomCheckley.Core.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly UmbracoHelper _umbracoHelper;

        public ArticleService(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }
        public List<ArticleCard> GetAll(Guid articleListingPageId)
        {
            IPublishedContent articleListingPage = _umbracoHelper.Content(articleListingPageId);
            var allItems = GetAllChildren(articleListingPage);
            return allItems.Select(c => new ArticleCard(c))
                           .ToList();
        }

        public PaginatedArticleCardsList GetPaged(Guid articleListingPageId, int page, int amountPerPage, params Guid[] ignoreIds)
        {
            if (amountPerPage == 0)
            {
                return new PaginatedArticleCardsList();
            }

            var articleListingPage = _umbracoHelper.Content(articleListingPageId);
            List<IPublishedContent> allItems = GetAllChildren(articleListingPage);

            List<ArticleCard> pagedResults = allItems.Where(c => !ignoreIds.Contains(c.Key))
                                                .Skip((page - 1) * amountPerPage)
                                                .Take(amountPerPage)
                                                .Select(c => new ArticleCard(c))
                                                .ToList();

            return new PaginatedArticleCardsList
            {
                BaseUrl = articleListingPage.Url(),
                Items = pagedResults,
                CurrentPage = page,
                ItemsPerPage = amountPerPage,
                TotalItems = pagedResults.Count
            };
        }

        public bool IsArticleValid(IPublishedContent content)
        {
            return content.IsComposedOf("compositionArticle") && content.Value<DateTime>("publishDate") <= DateTime.Now;
        }

        private List<IPublishedContent> GetAllChildren(IPublishedContent articleListingPage)
        {
            return articleListingPage.Children
                    .Where(IsArticleValid)
                    .OrderByDescending(date => date.Value<DateTime>("publishDate"))
                    .ToList();
        }
    }
}
