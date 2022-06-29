using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Models.PageTypes.Base;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace TomCheckley.Core.Controllers.Pages
{
    public class DefaultController : RenderController
    {
        protected readonly IPageFactory _pageFactory;
        protected readonly IUmbracoHelperAccessor _umbracoHelperAccessor;
        protected UmbracoHelper _umbracoHelper;


        public DefaultController(
            IPageFactory pageFactory,
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoHelperAccessor umbracoHelperAccessor)
                : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _pageFactory = pageFactory;
            _umbracoHelperAccessor = umbracoHelperAccessor;
        }

        /// <summary>
        /// This action is hit by default for all requests.
        /// It can be overridden by a Controller with the name of the DocumentTypeAlias, and an Action with the name of the Template.
        /// For example, a page at /cookie-policy/ built using a TextPage doctype and a LegalPage.cshtml would be routed to the TextPageController and the LegalPage action.
        /// </summary>
        public override IActionResult Index()
        {
            IPageBase model = _pageFactory.CreateModel(CurrentPage);
            return View(model);
        }

        public virtual IActionResult View(IPageBase model)
        {
            return View(UmbracoRouteValues.TemplateName, model);
        }

        public UmbracoHelper UmbracoHelper
        {
            get
            {
                if (_umbracoHelperAccessor != null && _umbracoHelperAccessor.TryGetUmbracoHelper(out var umbracoHelper))
                {
                    // If TryGetUmbracoHelper returns false, we couldn't get the helper because there was no HTTP Context
                    // This should not happen in an Umbraco Controller
                    return _umbracoHelper = umbracoHelper;
                }

                return null;
            }
        }
    }
}
