using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.Models.Media
{
    public class CropType
    {
        /// <summary>
        /// The name of the crop in Umbraco
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// The base width of the crop.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// The base height of the crop.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// The ratio of the crop, calculated as height / width (eg, 1080 x 1920 = 0.5625)
        /// </summary>
        public float Ratio => Height / Width;
    }
}
