using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ArticlePage : ModularPage
    {
        public DateTime DatePublished => _content.Value<DateTime>("datePublished");

        public ArticlePage(IPublishedContent content) : base(content)
        {
        }
    }
}
