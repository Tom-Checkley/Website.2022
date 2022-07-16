using TomCheckley.Core.Models.PageTypes;
using TomCheckley.Core.Models.PageTypes.Base;
using TomCheckley.Core.SiteConstants.Strings;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories.Concrete
{
    public class PageFactory : UmbracoContentToModelFactory<IPageBase>, IPageFactory
    {
        public PageFactory() : base(Namespaces.PageTypes, $", {Namespaces.Core}", typeof(UnknownPageType)) { }

        public PageFactory(string pageTypeNamespace, string appendToDocTypeAlias = "", Type fallbackType = null)
            : base(pageTypeNamespace, appendToDocTypeAlias, fallbackType) { }

        public IPageBase CreateModel(IPublishedContent content, params object[] args)
        {
            return base.Create(content, args);
        }
    }
}
