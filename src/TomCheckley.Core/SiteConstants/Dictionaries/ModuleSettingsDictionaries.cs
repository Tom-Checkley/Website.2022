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
    }
}
