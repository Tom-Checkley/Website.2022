using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Factories.Concrete;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.PageTypes
{
    public class ModularPage : UmbracoPageBase, IModular
    {

        public List<ISectionBase> Sections => GetSections("sections");

        public List<ISectionBase> GetSections(string alias)
        {
            if (_sections == null)
            {
                var factory = new SectionFactory();
                var value = _content.Value<BlockListModel>(alias);

                if (value == null)
                {
                    return new List<ISectionBase>();
                }

                _sections = value.Select(blockListModel => factory.CreateModel(blockListModel.Content, blockListModel.Settings))
                            .ToList();
            }

            return _sections;
        }

        private List<ISectionBase> _sections;

        public ModularPage(IPublishedContent content) : base(content)
        {
        }
    }
}
