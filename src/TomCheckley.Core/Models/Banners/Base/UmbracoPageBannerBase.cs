using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.Banners.Base
{
    public abstract class UmbracoPageBannerBase : UmbracoContentBase, IBannerBase
    {
        public abstract string RazorView { get; }

        public virtual BannerHeadingViewModel Heading => new(_content);

        protected UmbracoPageBannerBase(IPublishedContent content) : base(content)
        {
        }

    }
}
