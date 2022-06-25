using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Factories
{
    public interface IPageFactory
    {
        IPageBase CreateModel(IPublishedContent content, params object[] args);
    }
}
