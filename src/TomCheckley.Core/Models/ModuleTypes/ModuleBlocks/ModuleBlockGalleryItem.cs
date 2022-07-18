using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.Media;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.ModuleBlocks
{
    public class ModuleBlockGalleryItem : ModuleWithHeadingBase, IModuleSettings<ModuleBlockGalleryItemSettings>
    {
        public string Title => _content.Value<string>("title");
        public bool HasTitle => !Title.IsNullOrWhiteSpace();
        public UmbracoImage Image => new(_content.Value<IPublishedContent>("image"));
        public string Caption => _content.Value<string>("imageCaption");
        public bool HasCaption => !Caption.IsNullOrWhiteSpace();
        public override string RazorView => "Modules/ModuleBlocks/GalleryItem";

        public ModuleBlockGalleryItemSettings Settings
        {
            get
            {
                IModuleSettings<ModuleBlockGalleryItemSettings> imageBlockRef = this;
                return imageBlockRef.GetSettings(_settings);
            }
        }

        public ModuleBlockGalleryItem(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
