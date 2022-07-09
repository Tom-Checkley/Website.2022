using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Factories.Concrete;
using TomCheckley.Core.Services;
using TomCheckley.Core.Services.Concrete;
//using TomCheckley.Core.Services;
//using TomCheckley.Core.Services.Concrete;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace TomCheckley.Core.Composers
{
    public class StartupHandler : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            var services = builder.Services;

            // Force TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Factories
            services.AddTransient<IPageFactory, PageFactory>();
            services.AddTransient<ISectionFactory, SectionFactory>();
            //services.AddTransient<IModuleFactory, ModuleFactory>();
            services.AddTransient<IBannerFactory, BannerFactory>();

            // Services
            services.AddTransient<ICommonUmbracoContentService, CommonUmbracoContentService>();
            services.AddTransient<ISiteService, SiteService>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddTransient<ICompanyDetailsService, CompanyDetailsService>();
        }
    }
}
