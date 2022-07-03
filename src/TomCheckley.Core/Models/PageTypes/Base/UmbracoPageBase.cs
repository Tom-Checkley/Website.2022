using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.PageTypes.Base
{
    public abstract class UmbracoPageBase : UmbracoContentBase, IPageBase
    {
        //public string PageHeading => _content.Value("pageHeading", fallback: Fallback.ToDefaultValue, defaultValue: _content.Name);

        protected UmbracoPageBase(IPublishedContent content) : base(content)
        {
        }

    }
}
