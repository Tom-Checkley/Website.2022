using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ViewModels
{
    public class MainNavigation
    {
        public IPublishedContent HomePageLinkLogo { get; set; }
        public List<NavItem> NavItems { get; set; }
    }
}
