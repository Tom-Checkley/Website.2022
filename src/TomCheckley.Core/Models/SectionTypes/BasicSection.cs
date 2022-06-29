using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.SectionTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.SectionTypes
{
    public class BasicSection : SectionBase
    {
        private readonly IPublishedElement _settings;

        public BasicSection(IPublishedElement content, IPublishedElement settings) : base(content)
        {
            _settings = settings;
        }
    }
}
