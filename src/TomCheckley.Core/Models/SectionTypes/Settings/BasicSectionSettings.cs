using TomCheckley.Core.Models.SectionTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.SectionTypes.Settings
{
    public class BasicSectionSettings : SectionSettingsBase
    {
        public bool ReverseSection => _content.Value<bool>("reverseSection");

        public BasicSectionSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
