using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using TomCheckley.Core.SiteConstants;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories.Concrete
{
    public class ModuleSettingsFactory : UmbracoContentToModelFactory<ISettingsBase>, IModuleSettingsFactory
    {
        public ModuleSettingsFactory() : base(Namespaces.ModuleSettings, $", {Namespaces.Core}", typeof(ModuleSettingsBase)) { }
        public ModuleSettingsFactory(string modelNamespace, string appendToDocTypeAlias = "", Type fallbackType = null) 
            : base(modelNamespace, appendToDocTypeAlias, fallbackType)
        {
        }

        public ISettingsBase CreateModel(IPublishedElement settings, params object[] args)
        {
            var allArgs = new List<object>();
            allArgs.AddRange(args);
            var model = base.Create(settings, allArgs.ToArray());
            return model;
        }
    }
}
