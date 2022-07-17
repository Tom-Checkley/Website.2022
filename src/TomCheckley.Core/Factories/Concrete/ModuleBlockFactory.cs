using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;
using TomCheckley.Core.SiteConstants.Strings;

namespace TomCheckley.Core.Factories.Concrete
{
    public class ModuleBlockFactory : UmbracoContentToModelFactory<IModuleBase>, IModuleBlockFactory
    {
        public ModuleBlockFactory() : base(Namespaces.ModuleBlocks, $", {Namespaces.Core}", typeof(ModuleBase)) { }

        public ModuleBlockFactory(string modelNamespace, string appendToDocTypeAlias = "", Type fallbackType = null) : base(modelNamespace, appendToDocTypeAlias, fallbackType)
        {
        }

        public IModuleBase CreateModel(IPublishedElement content, IPublishedElement settings, params object[] args)
        {
            var allArgs = new List<object>
            {
                settings
            };
            allArgs.AddRange(args);
            var model = base.Create(content, allArgs.ToArray());
            return model;
        }
    }
}
