using TomCheckley.Core.Models.ViewModels;

namespace TomCheckley.Core.Services
{
    public interface ICompanyDetailsService
    {
        string GetCompanyName();
        string GetCompanyPhoneNumber();
        string GetCompanyEmail();
        Address GetCompanyAddress();
        SocialMediaLinks GetSocialMediaLinks();
    }
}
