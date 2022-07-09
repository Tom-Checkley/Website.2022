using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Services.Concrete
{
    public class NavigationService : INavigationService
    {
        private readonly ICommonUmbracoContentService _commonContentService;
        private readonly ILogger _logger;

        public NavigationService(ICommonUmbracoContentService commonContentService, ILogger logger)
        {
            _commonContentService = commonContentService;
            _logger = logger;
        }

        public MainNavigation GetMainNav()
        {
            if (_mainNav == null)
            {
                var settings = _commonContentService.GetSiteSettings();
                if (settings == null)
                {
                    _logger.Error($"Site Settings node could not be found, have you created it in Umbraco?");
                    return null;
                }
                if (_navItems == null)
                {
                    _navItems = new List<NavItem>();
                    var navItems = settings.Value<IEnumerable<IPublishedElement>>("mainNavItems");
                    if (navItems != null)
                    {
                        foreach (var navItem in navItems)
                        {
                            var linkContent = navItem.Value<IPublishedContent>("link");
                            if (linkContent != null)
                            {
                                _navItems.Add(new NavItem
                                {
                                    LinkText = navItem.Value<string>("linkText", fallback: Fallback.ToDefaultValue, defaultValue: linkContent.Name),
                                    Url = linkContent.Url(),
                                });
                            }
                            else
                            {
                                _logger.Warning($"Page with ID: {navItem.Key} doesn't exist or is unpublished and can not be added to Main Navigation.");
                            }
                        }
                    }
                }

                _mainNav = new MainNavigation
                {
                    HomePageLinkLogo = settings.Value<IPublishedContent>("homePageLinkLogo"),
                    NavItems = _navItems,
                };
            }
            return _mainNav;
        }
        private MainNavigation _mainNav;
        private List<NavItem> _navItems;
    }
}
