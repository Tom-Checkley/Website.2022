using Serilog;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace TomCheckley.Core.Services.Concrete
{
    public class CommonUmbracoContentService : ICommonUmbracoContentService
    {
        private readonly IUmbracoContextAccessor _context;
        private readonly ILogger _logger;
        private IPublishedContent _cachedHomePage;
        private IPublishedContent _siteSettings;

        public CommonUmbracoContentService(IUmbracoContextAccessor context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        private IPublishedContent _currentPage
        {
            get
            {
                return _context.GetRequiredUmbracoContext().PublishedRequest.PublishedContent;
            }
        }
        private IPublishedContent _homePage
        {
            get
            {
                if (_cachedHomePage == null)
                {
                    //using (var ucref = _contextFactory.EnsureUmbracoContext())
                    //{
                    //    _cachedHomePage = ucref.UmbracoContext.Content.GetByRoute("/");
                    //}

                    _cachedHomePage = _context.GetRequiredUmbracoContext().Content.GetByRoute("/");
                }
                return _cachedHomePage;
            }
        }

        public IPublishedContent GetCurrentPage()
        {
            return _currentPage;
        }

        public IPublishedContent GetHomePage()
        {
            return _homePage;
        }

        public IPublishedContent GetSiteSettings()
        {
            if (_siteSettings == null)
            {
                var siteSettings = _homePage.Siblings().FirstOrDefault(x => x.ContentType.Alias == "siteSettings");
                if (siteSettings != null)
                {
                    _siteSettings = siteSettings;
                }
                else
                {
                    _logger.Warning("Site Settings Node could not be found. Have you created one at the project root?");
                }
            }
            return _siteSettings;
        }
    }
}
