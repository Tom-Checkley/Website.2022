using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.SiteConstants.Dictionaries;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Settings
{
    public class MediaModuleSettings : ModuleSettingsBase, ISettingsBase
    {
        public string MediaPosition
        {
            get
            {
                var value = _content.Value<string>("mediaPosition", fallback: Fallback.ToDefaultValue, defaultValue: "Right");
                if (!ModuleSettingsDictionaries.MediaPosition.TryGetValue(value, out string output))
                {
#if DEBUG
                    throw new Exception($"Value: {value} could not be mapped, check that it has been added to the dictionary if required.");
#endif
                }
                return output;
            }
        }

        public string MediaSize
        {
            get
            {
                var value = _content.Value<string>("mediaSize", fallback: Fallback.ToDefaultValue, defaultValue: "Large");
                if (!ModuleSettingsDictionaries.MediaSize.TryGetValue(value, out string output))
                {
#if DEBUG
                    throw new Exception($"Value: {value} could not be mapped, check that it has been added to the dictionary if required.");
#endif
                }
                return output;
            }
        }

        public MediaModuleSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
