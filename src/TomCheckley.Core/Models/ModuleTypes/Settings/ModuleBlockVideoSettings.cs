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
    public class ModuleBlockVideoSettings : ModuleSettingsBase, ISettingsBase
    {
        public bool AllowFullScreen => _content.Value<bool>("allowFullScreen");
        public ModuleBlockVideoSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
