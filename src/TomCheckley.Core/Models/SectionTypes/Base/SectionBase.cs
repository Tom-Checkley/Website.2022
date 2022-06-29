using TomCheckley.Core.Factories.Concrete;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.SectionTypes.Base
{
    public abstract class SectionBase : UmbracoElementBase, ISectionBase
    {
        public Guid Id => _content.Key;
        public virtual string RazorView => $"Sections/{_content.ContentType.Alias }";
        public string Heading => _content.Value<string>("heading");
        public bool HasHeading => !Heading.IsNullOrWhiteSpace();
        public List<IModuleBase> Modules
        {
            get
            {
                if (_modules == null)
                {
                    _modules = new List<IModuleBase>();
                    var factory = new ModuleFactory();
                    var value = _content.Value<BlockListModel>("modules");

                    if (value != null)
                    {
                        _modules = value.Select(blockListModel => factory.CreateModel(blockListModel.Content, blockListModel.Settings, this))
                                        .ToList();
                    }
                }
                return _modules;
            }
        }

        private List<IModuleBase> _modules;

        public SectionBase(IPublishedElement content) : base(content)
        {
        }
    }
}
