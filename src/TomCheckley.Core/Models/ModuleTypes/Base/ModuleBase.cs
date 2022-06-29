using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public class ModuleBase : UmbracoElementBase, IModuleBase
    {
        protected IPublishedElement _settings;

        public Guid Id => _content.Key;
        public string RazorView => $"Modules/{_content.ContentType.Alias}";

        //public IPublishedElement Settings { get; private set; }
        public ISectionBase ParentSection { get; private set; }

        public ModuleBase(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content)
        {
            _settings = settings;
            ParentSection = parentSection;
        }

    }
}
