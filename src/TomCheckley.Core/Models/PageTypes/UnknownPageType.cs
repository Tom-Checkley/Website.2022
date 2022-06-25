using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class UnknownPageType : UmbracoPageBase
    {
        public UnknownPageType(IPublishedContent content) : base(content)
        {
        }
    }
}
