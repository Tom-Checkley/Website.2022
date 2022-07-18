using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Factories.Concrete;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.ModuleBlocks;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes
{
    public class GalleryModule : ModuleWithHeadingBase, IModuleSettings<GalleryModuleSettings>
    {
        public HtmlEncodedString BodyText => _content.Value<HtmlEncodedString>("bodyText");
        public bool HasBodyText => !BodyText.ToString().IsNullOrWhiteSpace();
        public List<IModuleBase> Images
        {
            get
            {
                if (_images == null)
                {
                    _images = new List<IModuleBase>();
                    var images = _content.Value<BlockListModel>("images");

                    if (images != null)
                    {
                        var factory = FactoryFactory.GetService<IModuleBlockFactory>();
                        _images = images.Select(blockListModel => factory.CreateModel(blockListModel.Content, blockListModel.Settings, ParentSection)).ToList();
                    }

                }
                return _images;
            }
        }
        private List<IModuleBase> _images;

        public GalleryModuleSettings Settings
        {
            get
            {
                IModuleSettings<GalleryModuleSettings> galleryModuleRef = this;
                return galleryModuleRef.GetSettings(_settings);
            }
        }

        public GalleryModule(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }

    }
}
