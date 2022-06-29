using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.SectionTypes.Base
{
    public class SectionSettingsBase : UmbracoElementBase
    {
        public SectionSettingsBase(IPublishedElement content) : base(content)
        {
        }
    }
}
