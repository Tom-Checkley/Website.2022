using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public abstract class ModuleWithHeadingBase : ModuleBase
    {
        public string Heading => _content.Value<string>("heading");
        public bool HasHeading => !Heading.IsNullOrWhiteSpace();

        public ModuleWithHeadingBase(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
