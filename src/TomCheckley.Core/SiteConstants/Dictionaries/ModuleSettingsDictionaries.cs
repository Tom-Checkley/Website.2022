using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.SiteConstants.Dictionaries
{
    public static class ModuleSettingsDictionaries
    {
        public static Dictionary<string, string> TextAlign = new()
        {
            { "Left", "left" },
            { "Centre", "center" },
            { "Right", "right" },
        };

        public static Dictionary<string, string> ObjectFit = new()
        {
            { "None", "" },
            { "Cover", "cover" },
            { "Contain", "contain" },
        };

        public static Dictionary<string, string> MediaPosition = new()
        {
            { "Left", "left" },
            { "Right", "right" },
        };

        public static Dictionary<string, string> MediaSize = new()
        {
            { "Small", "small" },
            { "Medium", "medium" },
            { "Large", "large" },
        };

    }
}
