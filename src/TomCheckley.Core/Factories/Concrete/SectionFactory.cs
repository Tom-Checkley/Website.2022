﻿using TomCheckley.Core.SiteConstants;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.SectionTypes;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories.Concrete
{
    public class SectionFactory : UmbracoContentToModelFactory<ISectionBase>, ISectionFactory
    {
        public SectionFactory() : base(Namespaces.SectionTypes, $", {Namespaces.Core}", typeof(BasicSection)) { }

        public SectionFactory(string sectionTypenameSpace, string appendToDocTypeAlias = "", Type fallbackType = null)
            : base(sectionTypenameSpace, appendToDocTypeAlias, fallbackType) { }

        public ISectionBase CreateModel(IPublishedElement content, IPublishedElement settings, params object[] args)
        {
            var allArgs = new List<object>
            {
                settings
            };
            allArgs.AddRange(args);
            return base.Create(content, allArgs.ToArray());
        }
    }
}
