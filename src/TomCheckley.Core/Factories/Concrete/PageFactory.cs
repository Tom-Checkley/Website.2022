using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Constants;
using TomCheckley.Core.Models.PageTypes;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories.Concrete
{
    public class PageFactory : UmbracoContentToModelFactory<IPageBase>, IPageFactory
    {
        public PageFactory() : base(Namespace.PageTypes, $", {Namespace.Core}", typeof(UnknownPageType)) { }

        public PageFactory(string pageTypeNamespace, string appendToDocTypeAlias = "", Type fallbackType = null)
            : base(pageTypeNamespace, appendToDocTypeAlias, fallbackType) { }

        public IPageBase CreateModel(IPublishedContent content, params object[] args)
        {
            return base.Create(content, args);
        }
    }
}
