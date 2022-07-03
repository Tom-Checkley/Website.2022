using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Banners.Base;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Banners
{
    public class HomePageBanner : UmbracoPageBannerBase
    {
        public override BannerHeading Heading => new(_content);

        public override string RazorView => "Banners/HomePageBanner";

        public HomePageBanner(IPublishedContent content) : base(content)
        {
        }
    }
}
