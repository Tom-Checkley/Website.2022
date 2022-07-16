using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.SiteConstants.Dictionaries;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Settings
{
    public class TextModuleSettings : ModuleSettingsBase
    {
        private readonly ILogger _logger;

        public string TextAlign
        {
            get
            {
                var value = _content.Value<string>("textAlign", fallback: Fallback.ToDefaultValue, defaultValue: "Left");
                if (!ModuleSettingsDictionaries.TextAlign.TryGetValue(value, out string output))
                {
#if DEBUG
                    throw new Exception($"Value: {value} could not be mapped, check that it has been added to the dictionary if required.");
#endif
                }
                return output;
            }
        }

        public TextModuleSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
