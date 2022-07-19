using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.Cards;

namespace TomCheckley.Core.Models.ViewModels
{
    public class PaginatedArticleCardsListViewModel : PaginatedList<ArticleCard>
    {
        public ArticleCard FeaturedArticleCard { get; internal set; }
        public bool HasFeaturedArticle { get; internal set; }
        public string BaseUrl { get; set; }
    }
}
