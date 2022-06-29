using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories
{
    public interface ISectionFactory
    {
        ISectionBase CreateModel(IPublishedElement content, params object[] args);
        //ISectionBase CreateModel(IPublishedElement content, IPublishedValueFallback settings, params object[] args);
    }
}
