using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes
{
    public class TextModule : ModuleBase
    {
        public string Heading => _content.Value<string>("heading");
        public bool HasHeading => !Heading.IsNullOrWhiteSpace();
        public HtmlEncodedString BodyText => _content.Value<HtmlEncodedString>("bodyText");

        public TextModule(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
