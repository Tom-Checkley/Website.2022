using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories
{
    public interface IModuleFactory
    {
        IModuleBase CreateModel(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection, params object[] args);
    }
}
