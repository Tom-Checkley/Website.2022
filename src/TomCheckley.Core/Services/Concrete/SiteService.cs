using TomCheckley.Core.Models.Media;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Services.Concrete
{
    public class SiteService : ISiteService
    {
        private readonly ICommonUmbracoContentService _commonContentService;

        public SiteService(ICommonUmbracoContentService commonContentService)
        {
            _commonContentService = commonContentService;
        }

        public MetaDataViewModel GetMetaData()
        {
            var siteSettings = _commonContentService.GetSiteSettings();
            var currentPage = _commonContentService.GetCurrentPage();
            var websiteDescription = siteSettings.Value<string>("websiteDescription", fallback: Fallback.ToDefaultValue, defaultValue: string.Empty);

            return new MetaDataViewModel
            {
                WebsiteName = siteSettings.Value<string>("websiteName"),
                Title = currentPage.Value<string>("seoTitle", fallback: Fallback.ToDefaultValue, defaultValue: currentPage.Name),
                Description = currentPage.Value<string>("seoDescription", fallback: Fallback.ToDefaultValue, defaultValue: websiteDescription),
                AbsoluteUrl = currentPage.Url(mode: UrlMode.Absolute),
                SocialShareImage = new UmbracoImage(currentPage.Value("socialShareImage", fallback: Fallback.ToDefaultValue, defaultValue: siteSettings.Value<IPublishedContent>("socialShareImage"))),
            };
        }
    }
}
