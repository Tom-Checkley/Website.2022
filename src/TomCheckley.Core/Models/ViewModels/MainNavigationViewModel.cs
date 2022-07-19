using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ViewModels
{
    public class MainNavigationViewModel
    {
        public IPublishedContent HomePageLinkLogo { get; set; }
        public List<NavItemViewModel> NavItems { get; set; }
    }
}
