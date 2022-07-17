using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public class ModuleSettingsBase : UmbracoElementBase, ISettingsBase
    {
        public ModuleSettingsBase(IPublishedElement content) : base(content)
        {
        }
    }
}
