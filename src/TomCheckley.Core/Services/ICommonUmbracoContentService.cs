using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Services
{
    public interface ICommonUmbracoContentService
    {
        IPublishedContent GetHomePage();
        IPublishedContent GetCurrentPage();
        IPublishedContent GetSiteSettings();
    }
}
