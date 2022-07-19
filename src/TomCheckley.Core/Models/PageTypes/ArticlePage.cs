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
        public DateTime PublishDate => _content.Value<DateTime>("publishDate");

        public ArticlePage(IPublishedContent content) : base(content)
        {
        }
    }
}
