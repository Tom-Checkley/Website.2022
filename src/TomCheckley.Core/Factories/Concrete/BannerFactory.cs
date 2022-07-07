using TomCheckley.Core.Constants;
using TomCheckley.Core.Models.Banners;
using TomCheckley.Core.Models.Banners.Base;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace TomCheckley.Core.Factories.Concrete
{
    public class BannerFactory : IBannerFactory
    {
        private readonly IUmbracoContextAccessor _context;
        public BannerFactory(IUmbracoContextAccessor context)
        {
            _context = context;
        }

        public IBannerBase CreateModel()
        {
            var publishedRequest = _context.GetRequiredUmbracoContext().PublishedRequest;
            var content = publishedRequest?.PublishedContent;

            if (content != null)
            {

                if (content.IsComposedOf(DocTypes.HomePageBanner))
                {
                    return new HomePageBanner(content);
                }
                else if (content.IsComposedOf(DocTypes.StandardBanner))
                {
                    return new StandardBanner(content);
                }
                return new NoBanner(content);
            }
            else
            {
                throw new Exception($"No content could be found for { publishedRequest }");
            }
        }
    }
}
