using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Settings
{
    public class ModuleBlockGalleryItemSettings : ModuleSettingsBase, ISettingsBase
    {
        public bool DisplayCaption => _content.Value<bool>("displayCaptionWithThumbnail");
        public ModuleBlockGalleryItemSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
