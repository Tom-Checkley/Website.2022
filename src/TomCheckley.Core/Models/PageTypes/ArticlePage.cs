using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ArticlePage : UmbracoPageBase
    {
        public ArticlePage(IPublishedContent content) : base(content)
        {
        }
    }
}
