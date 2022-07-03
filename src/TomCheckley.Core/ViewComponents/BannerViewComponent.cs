using Microsoft.AspNetCore.Mvc;
using TomCheckley.Core.Factories;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace TomCheckley.Core.ViewComponents
{
    public partial class BannerViewComponent : ViewComponent
    {
        private readonly IBannerFactory _bannerFactory;

        public BannerViewComponent(IBannerFactory bannerFactory)
        {
            _bannerFactory = bannerFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banner = _bannerFactory.CreateModel();

            if (banner == null)
            {
                return null;
            }
            return View(banner);
        }
    }
}
