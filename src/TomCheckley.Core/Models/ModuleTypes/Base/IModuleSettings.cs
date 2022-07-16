using TomCheckley.Core.Factories;
using TomCheckley.Core.Factories.Concrete;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.ModuleTypes.Base
{
    public interface IModuleSettings<T>
    {
        T Settings { get; }
        T GetSettings(IPublishedElement settings)
        {
            var factory = FactoryFactory.GetService<IModuleSettingsFactory>();
            var model = factory.CreateModel(settings);
            return (T)model;

        }
    }
}
