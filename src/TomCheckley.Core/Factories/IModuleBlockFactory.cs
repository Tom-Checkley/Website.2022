using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories
{
    public interface IModuleBlockFactory
    {
        IModuleBase CreateModel(IPublishedElement content, IPublishedElement settings, params object[] args);
    }
}
