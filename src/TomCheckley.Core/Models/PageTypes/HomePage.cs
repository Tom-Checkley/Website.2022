using TomCheckley.Core.Factories;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.PageTypes
{
    public class HomePage : ModularPage
    {
        public HomePage(IPublishedContent content) : base(content)
        {
        }
    }
}
