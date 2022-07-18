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
    public class ModuleBlockImage : ModuleBase, IModuleSettings<ModuleBlockImageSettings>
    {
        public UmbracoImage Image => new(_content.Value<IPublishedContent>("image"));
        public string Caption => _content.Value<string>("imageCaption");
        public bool HasCaption => !Caption.IsNullOrWhiteSpace();
        public override string RazorView => "Modules/ModuleBlocks/Image";

        public virtual ModuleBlockImageSettings Settings
        {
            get
            {
                IModuleSettings<ModuleBlockImageSettings> imageBlockRef = this;
                return imageBlockRef.GetSettings(_settings);
            }
        }

        public ModuleBlockImage(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
