using Microsoft.AspNetCore.Mvc;
using Serilog;
using TomCheckley.Core.Services;

namespace TomCheckley.Core.ViewComponents
{
    public class MainNavigationViewComponent : ViewComponent
    {
        private readonly INavigationService _navService;
        private readonly ILogger _logger;

        public MainNavigationViewComponent(INavigationService navService, ILogger logger)
        {
            _navService = navService;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mainNav = _navService.GetMainNav();

            if (mainNav == null)
            {
                _logger.Error($"Navigation node could not be found, have you created it in Umbraco?");
                return null;
            }
            return View(mainNav);
        }
    }
}
