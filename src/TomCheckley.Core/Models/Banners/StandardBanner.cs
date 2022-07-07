using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Banners.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.Banners
{
    public class StandardBanner : UmbracoPageBannerBase
    {
        public override string RazorView => "Banners/StandardBanner";

        public StandardBanner(IPublishedContent content) : base(content)
        {
        }

    }
}
