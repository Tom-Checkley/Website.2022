using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.Media;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.ModuleBlocks
{
    public class ModuleBlockVideo : ModuleBase, IModuleSettings<ModuleBlockVideoSettings>
    {
        public string EmbedUrl => _content.Value<string>("embedUrl");
        public string Title => _content.Value<string>("title");
        public HtmlEncodedString Caption => _content.Value<HtmlEncodedString>("caption");
        public bool HasCaption => !Caption.ToString().IsNullOrWhiteSpace();
        public UmbracoImage Thumbnail => new(_content.Value<IPublishedContent>("thumbnail"));

        public override string RazorView => "Modules/ModuleBlocks/Video";

        public ModuleBlockVideoSettings Settings
        {
            get
            {
                if (_videoBlockSettings == null)
                {
                    IModuleSettings<ModuleBlockVideoSettings> videoBlockRef = this;
                    _videoBlockSettings = videoBlockRef.GetSettings(_settings);
                }
                return _videoBlockSettings;
            }
        }
        private ModuleBlockVideoSettings _videoBlockSettings;

        public ModuleBlockVideo(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }

    }
}
