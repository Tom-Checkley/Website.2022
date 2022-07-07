using TomCheckley.Core.Constants;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories.Concrete
{
    public class ModuleFactory : UmbracoContentToModelFactory<IModuleBase>, IModuleFactory
    {
        public ModuleFactory() : base(Namespaces.ModuleTypes, $", {Namespaces.Core}", typeof(ModuleBase)) { }

        public ModuleFactory(string modelNamespace, string appendToDocTypeAlias = "", Type fallbackType = null) : base(modelNamespace, appendToDocTypeAlias, fallbackType)
        {
        }

        public IModuleBase CreateModel(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection, params object[] args)
        {
            var allArgs = new List<object>
            {
                settings,
                parentSection
            };
            allArgs.AddRange(args);
            var model = base.Create(content, allArgs.ToArray());
            return model;
        }
    }
}
