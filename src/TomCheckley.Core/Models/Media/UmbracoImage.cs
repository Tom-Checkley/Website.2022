using TomCheckley.Core.Extensions;
using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Media
{
    public class UmbracoImage : UmbracoMedia, IImage
    {
        public string AltText => Exists ? _content.Value<string>("altText", fallback: Fallback.ToDefaultValue, defaultValue: string.Empty) : null;
        public float Ratio => Exists && Width != 0 ? (float)Height / (float)Width : 0;
        public int Width => Exists ? _content.Value(Constants.Conventions.Media.Width, fallback: Fallback.ToDefaultValue, defaultValue: 0) : 0;
        public int Height => Exists ? _content.Value(Constants.Conventions.Media.Height, fallback: Fallback.ToDefaultValue, defaultValue: 0) : 0;

        public UmbracoImage(IPublishedContent content) : base(content)
        {
        }

        public string GetCropUrl(CropType cropType)
        {
            if (!Exists)
            {
                return string.Empty;
            }
            if (cropType == null)
            {
                return Url;
            }
            return _content.GetCropUrl(cropType.Alias);
        }

        public string GetCropUrl(CropType cropType, int width)
        {
            if (!Exists)
            {
                return string.Empty;
            }
            if (cropType == null)
            {
                return GetCustomCrop(width, (int)(width * Ratio));
            }
            return GetModifiedCrop(cropType, width, (int)(width * cropType.Ratio));
        }

        public string GetAbsoluteCropUrl(CropType cropType)
        {
            if (!Exists)
            {
                return string.Empty;
            }
            return _content.GetCropUrl(cropType.Alias, UrlMode.Absolute);
        }

        public string GetCustomCrop(int width, int height)
        {
            decimal focalX = 0.5m;
            decimal focalY = 0.5m;

            ImageCropperValue cropData = _content.Value<ImageCropperValue>("umbracoFile");
            if (cropData.HasFocalPoint())
            {
                focalX = cropData.FocalPoint.Left;
                focalY = cropData.FocalPoint.Top;
            }

            string cUrl = Url.UpdateQueryStringValue("mode", "crop")
                          .UpdateQueryStringValue("center", focalX + "," + focalY)
                          .UpdateQueryStringValue("width", width.ToString())
                          .UpdateQueryStringValue("height", height.ToString())
                          .UpdateQueryStringValue("rnd", width + "_" + height + "_" + focalX + "_" + focalY);

            return cUrl;
        }

        private string GetModifiedCrop(CropType cropType, int width, int height)
        {
            return GetCropUrl(cropType).UpdateQueryStringValue("width", width.ToString())
                                       .UpdateQueryStringValue("height", height.ToString())
                                       .UpdateQueryStringValue("rnd", cropType.Alias + "_" + width + "_" + height);
        }
    }
}
