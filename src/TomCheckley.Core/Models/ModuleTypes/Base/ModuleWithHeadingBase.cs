using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public abstract class ModuleWithHeadingBase : ModuleBase
    {
        public ModuleHeadingViewModel Heading => new(_content, ParentSectionHasHeading);
        public bool HasHeading => Heading.HasHeading;
        public bool ParentSectionHasHeading => ParentSection.HasHeading;

        public ModuleWithHeadingBase(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
