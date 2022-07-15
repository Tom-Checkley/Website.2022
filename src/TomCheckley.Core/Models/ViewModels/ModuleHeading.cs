using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ViewModels
{
    public class ModuleHeading : UmbracoElementBase
    {
        private readonly ISectionBase _parentSection;

        public string Heading => _content.Value<string>("heading");
        public bool HasHeading => !Heading.IsNullOrWhiteSpace();
        public string Subheading => _content.Value<string>("subheading");
        public bool HasSubheading => !Subheading.IsNullOrWhiteSpace();
        public bool ParentSectionHasHeading => _parentSection.HasHeading;

        public ModuleHeading(IPublishedElement content, ISectionBase parentSection) : base(content)
        {
            _parentSection = parentSection;
        }
    }
}
