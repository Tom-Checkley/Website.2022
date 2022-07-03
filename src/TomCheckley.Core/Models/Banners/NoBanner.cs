using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Banners.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.Banners
{
    public class NoBanner : UmbracoPageBannerBase, IBannerBase
    {
        public override string RazorView => $"Banners/NoBanner";

        public NoBanner(IPublishedContent content) : base(content)
        {
        }
    }
}
