using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes
{
    public class MediaModule : ModuleWithHeadingBase
    {
        public HtmlEncodedString BodyText => _content.Value<HtmlEncodedString>("bodyText");
        public Link Button => _content.Value<Link>("button");

        public MediaModule(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
