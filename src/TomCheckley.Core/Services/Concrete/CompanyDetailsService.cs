using TomCheckley.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Services.Concrete
{
    public class CompanyDetailsService : ICompanyDetailsService
    {
        private IPublishedContent _settings;

        public CompanyDetailsService(ICommonUmbracoContentService commonContentService)
        {
            _settings = commonContentService.GetSiteSettings();
        }

        public Address GetCompanyAddress()
        {
            return new Address
            {
                AddressLine1 = _settings.Value<string>("addressLine1"),
                AddressLine2 = _settings.Value<string>("addressLine2"),
                TownCity = _settings.Value<string>("townCiy"),
                County = _settings.Value<string>("county"),
                Postcode = _settings.Value<string>("postcode")
            };
        }

        public string GetCompanyEmail()
        {
            return _settings.Value<string>("email");
        }

        public string GetCompanyName()
        {
            return _settings.Value<string>("companyName");
        }

        public string GetCompanyPhoneNumber()
        {
            return _settings.Value<string>("phoneNumber");
        }

        public SocialMediaLinks GetSocialMediaLinks()
        {
            return new SocialMediaLinks
            {
                FacebookUrl = _settings.Value<string>("facebookUrl"),
                TwitterUrl = _settings.Value<string>("twitterUrl"),
                LinkedInUrl = _settings.Value<string>("linkedInUrl"),
                GithubUrl = _settings.Value<string>("githubUrl"),
            };
        }
    }
}
