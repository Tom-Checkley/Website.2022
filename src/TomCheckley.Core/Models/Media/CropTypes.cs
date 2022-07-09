namespace TomCheckley.Core.Models.Media
{
    public static class CropTypes
    {
        public static readonly CropType Square = new() { Alias = "Square", Width = 720f, Height = 720f };
        public static readonly CropType BannerFull = new() { Alias = "BannerFull", Width = 1920f, Height = 1080f };
        public static readonly CropType Banner = new() { Alias = "Banner", Width = 1920f, Height = 600f };
        public static readonly CropType Landscape = new() { Alias = "Landscape", Width = 900f, Height = 600f };
        public static readonly CropType Portrait = new() { Alias = "Portrait", Width = 700f, Height = 900f };
        public static readonly CropType SocialShare = new() { Alias = "SocialShare", Width = 1200f, Height = 630f };
    }
}
