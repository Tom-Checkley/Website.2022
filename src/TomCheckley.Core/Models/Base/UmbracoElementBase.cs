using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.Base
{
    public abstract class UmbracoElementBase
    {
        protected IPublishedElement _content;
        public virtual bool Exists => _content != null;

        protected UmbracoElementBase(IPublishedElement content)
        {
            _content = content;
        }
    }
}
