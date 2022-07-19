using TomCheckley.Core.Models.Cards;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ArticleListingPage : ModularPage
    {
        public PaginatedArticleCardsListViewModel Items { get; internal set; }

        public ArticleListingPage(IPublishedContent content) : base(content)
        {
        }
    }
}
