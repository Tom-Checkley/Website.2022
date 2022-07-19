using TomCheckley.Core.Models.Cards.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Cards
{
    public class ArticleCard : CardBase
    {
        public DateTime DatePublished => _content.Value<DateTime>("datePublished");
        public virtual string RazorView => $"Cards/ArticleCard";

        public ArticleCard(IPublishedContent content) : base(content)
        {
        }
    }
}
