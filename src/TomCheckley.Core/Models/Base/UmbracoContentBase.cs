using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Base
{
    public abstract class UmbracoContentBase : UmbracoElementBase
    {
        public new IPublishedContent _content;
        public virtual Guid Id => Exists ? _content.Key : Guid.Empty;
        public virtual string Url => Exists ? _content.Url() : string.Empty;
        public virtual string AsoluteUrl => Exists ? _content.Url(mode: UrlMode.Absolute) : string.Empty;
        public virtual string Name => Exists ? _content.Name : string.Empty;

        public UmbracoContentBase(IPublishedContent content) : base(content)
        {
            _content = content;
        }

        public IPublishedContent GetContent()
        {
            return _content;
        }
    }
}
