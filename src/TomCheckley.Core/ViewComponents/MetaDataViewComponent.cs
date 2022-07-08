using Microsoft.AspNetCore.Mvc;
using TomCheckley.Core.Services;

namespace TomCheckley.Core.ViewComponents
{
    public class MetaDataViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public MetaDataViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _siteService.GetMetaData();
            return View(model);
        }
    }
}
