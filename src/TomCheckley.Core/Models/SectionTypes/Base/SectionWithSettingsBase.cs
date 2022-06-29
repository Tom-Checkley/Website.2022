using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.SectionTypes.Base
{
    public class SectionWithSettingsBase : SectionBase
    {
        public virtual SectionSettingsBase Settings { get; }

        public SectionWithSettingsBase(IPublishedElement content) : base(content)
        {
        }
    }
}
