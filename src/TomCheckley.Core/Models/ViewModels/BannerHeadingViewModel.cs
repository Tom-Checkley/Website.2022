using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ViewModels
{
    public class BannerHeadingViewModel : UmbracoContentBase
    {
        public string HeadingLine1 => _content.Value("bannerHeadingLine1", fallback: Fallback.ToDefaultValue, defaultValue: _content.Name);
        public bool HasHeading => !HeadingLine1.IsNullOrWhiteSpace();
        public string HeadingLine2 => _content.Value<string>("bannerHeadingLine2");
        public bool HasHeadingLine2 => !HeadingLine2.IsNullOrWhiteSpace();
        public string HeadingSeparator => _content.Value<string>("bannerHeadingSeparator");
        public bool HasSeparator => !HeadingSeparator.IsNullOrWhiteSpace();

        public BannerHeadingViewModel(IPublishedContent content) : base(content)
        {
        }
    }
}
