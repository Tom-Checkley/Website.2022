using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Settings
{
    public class TextModuleSettings : ModuleSettingsBase
    {
        public string TextAlign
        {
            get
            {
                var value = _content.Value<string>("textAlign", fallback: Fallback.ToDefaultValue, defaultValue: "Left");
                string output;
                switch (value)
                {
                    case "Right":
                        output = "right";
                        break;
                    case "Centre":
                        output = "center";
                        break;
                    default:
                        output = "left";
                        break;
                }
                return output;
            }
        }

        public TextModuleSettings(IPublishedElement content) : base(content)
        {
        }
    }
}
