using TomCheckley.Core.Models.Cards;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Services
{
    public interface IArticleService
    {
        PaginatedArticleCardsListViewModel GetPaged(Guid articleListingPageId, int page, int amountPerPage, params Guid[] ignoreIds);
        List<ArticleCard> GetAll(Guid articleListingPageId);
        bool IsArticleValid(IPublishedContent content);
    }
}
