using TomCheckley.Core.Models.SectionTypes.Base;
using TomCheckley.Core.Models.SectionTypes.Settings;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.SectionTypes
{
    public class BasicSection : SectionWithSettingsBase
    {
        private readonly IPublishedElement _settings;

        public override BasicSectionSettings Settings => new(_settings);

        public BasicSection(IPublishedElement content, IPublishedElement settings) : base(content)
        {
            _settings = settings;
        }
    }
}
