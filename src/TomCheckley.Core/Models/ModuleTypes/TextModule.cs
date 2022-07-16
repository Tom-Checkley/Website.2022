using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes
{
    public class TextModule : ModuleWithHeadingBase, IModuleSettings<TextModuleSettings>
    {
        public HtmlEncodedString BodyText => _content.Value<HtmlEncodedString>("bodyText");
        public TextModuleSettings Settings
        {
            get
            {
                if (_textModuleSettings == null)
                {
                    IModuleSettings<TextModuleSettings> textModule = this;
                    _textModuleSettings = textModule.GetSettings(_settings);
                }
                return _textModuleSettings;
            }
        }
        private TextModuleSettings _textModuleSettings;

        public TextModule(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
