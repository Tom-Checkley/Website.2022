using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ArticlePage : ModularPage
    {
        public DateTime PublishDate => _content.Value<DateTime>("publishDate");

        public ArticlePage(IPublishedContent content) : base(content)
        {
        }
    }
}
