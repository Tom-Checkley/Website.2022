using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public class ModuleWithSettingsBase : ModuleBase
    {
        public virtual ModuleSettingsBase Settings { get; }

        public ModuleWithSettingsBase(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
