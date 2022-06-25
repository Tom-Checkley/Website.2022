using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class HomePage : UmbracoPageBase
    {
        public HomePage(IPublishedContent content) : base(content)
        {
        }
    }
}
