using TomCheckley.Core.Models.ViewModels;

namespace TomCheckley.Core.Models.Banners.Base
{
    public interface IBannerBase
    {
        string RazorView { get; }
        BannerHeadingViewModel Heading { get; }
    }
}
