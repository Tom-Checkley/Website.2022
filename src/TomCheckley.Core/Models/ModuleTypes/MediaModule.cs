using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Factories.Concrete;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.ModuleTypes.Base;
using TomCheckley.Core.Models.ModuleTypes.Settings;
using TomCheckley.Core.Models.ViewModels;
using TomCheckley.Core.SiteConstants.Strings;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace TomCheckley.Core.Models.ModuleTypes
{
    public class MediaModule : ModuleWithHeadingBase, IModuleSettings<MediaModuleSettings>
    {
        public HtmlEncodedString BodyText => _content.Value<HtmlEncodedString>("bodyText");
        public Link Button => _content.Value<Link>("button");
        public List<IModuleBase> Media 
        {
            get
            {
                if (_media == null)
                {
                    _media = new List<IModuleBase>();
                    var value = _content.Value<BlockListModel>("media");
                    var factory = FactoryFactory.GetService<IModuleBlockFactory>();

                    if (value != null)
                    {
                        _media = value.Select(
                                    blockListModel => factory.CreateModel(
                                        blockListModel.Content,
                                        blockListModel.Settings,
                                        ParentSection)
                                    )
                                    .ToList();
                    }
                }
                return _media;
            }   
        }
        private List<IModuleBase> _media;

        public MediaModuleSettings Settings
        {
            get
            {
                if (_mediaModuleSettings == null)
                {
                    IModuleSettings<MediaModuleSettings> mediaModuleRef = this;
                    _mediaModuleSettings = mediaModuleRef.GetSettings(_settings);
                }
                return _mediaModuleSettings;
            }
        }
        private MediaModuleSettings _mediaModuleSettings;


        public MediaModule(IPublishedElement content, IPublishedElement settings, ISectionBase parentSection) : base(content, settings, parentSection)
        {
        }
    }
}
