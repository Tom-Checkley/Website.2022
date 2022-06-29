using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TomCheckley.Core.Models.Base
{
    public interface IModular
    {
        List<ISectionBase> Sections { get; }
        List<ISectionBase> GetSections(string alias);
    }
}
