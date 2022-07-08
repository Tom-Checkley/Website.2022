using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Media
{
    public class UmbracoMedia : UmbracoContentBase, IMedia
    {
        public double Size => Exists ? _content.Value<double>("umbracoBytes") : 0;
        public string AbsoluteUrl => Exists ? _content.Url(mode: UrlMode.Absolute) : string.Empty;

        public UmbracoMedia(IPublishedContent content) : base(content)
        {
        }
    }
}
