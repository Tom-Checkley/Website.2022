using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.Cards.Base
{
    public abstract class CardBase : UmbracoContentBase, ICardBase
    {
        public virtual string CardHeading
        {
            get
            {
                var heading = _content.Value<string>("cardHeading");

                if (heading == null)
                {
                    var fallback = _content.Value<string>("bannerHeadingLine1");
                    if (fallback.IsNullOrWhiteSpace())
                    {
                        fallback = _content.Name;
                    }
                    else
                    {
                        var separator = _content.Value<string>("bannerHeadingSeparator");
                        var line2 = _content.Value<string>("bannerHeadingLine2");

                        if (!separator.IsNullOrWhiteSpace())
                        {
                            fallback += separator;
                        }
                        if (!line2.IsNullOrWhiteSpace())
                        {
                            fallback += line2;
                        }
                    }
                    heading = fallback;
                }
                return heading;
            }
        }
        public virtual string CardExcerpt => _content.Value<string>("cardExcerpt");
        public bool HasExcerpt => !CardExcerpt.IsNullOrWhiteSpace();
        public virtual string CardLink => _content.Url();
        public virtual string CardButtonText => _content.Value<string>("cardButtonText", fallback: Fallback.ToDefaultValue, defaultValue: "Read more");

        protected CardBase(IPublishedContent content) : base(content)
        {
        }
    }
}
