using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.Models.Media
{
    public class CropTypes
    {
        public static CropType Square = new CropType { Alias = "Square", Width = 720f, Height = 720f };
        public static CropType RectangleLarge = new CropType { Alias = "RectangleLarge", Width = 1920f, Height = 1080f };
        public static CropType Landscape = new CropType { Alias = "Landscape", Width = 900f, Height = 600f };
        public static CropType Portrait = new CropType { Alias = "Portrait", Width = 900f, Height = 800f };
        public static CropType SocialShare = new CropType { Alias = "SocialShare", Width = 1200f, Height = 630f };
    }
}
