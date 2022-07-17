using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.SiteConstants.Dictionaries;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes.Settings
{
    public class ModuleBlockImageSettings : ModuleSettingsBase
    {
        public string ObjectFit
        {
            get
            {
                var value = _content.Value<string>("imageCrop", fallback: Fallback.ToDefaultValue, defaultValue: "None");
                if (!ModuleSettingsDictionaries.ObjectFit.TryGetValue(value, out string output))
                {
#if DEBUG
                    throw new Exception($"Value: {value} could not be mapped, check that it has been added to the dictionary if required.");
#endif
                }
                return output;
            }
        }

        public ModuleBlockImageSettings(IPublishedElement content) : base(content)
        {
        }


    }
}
