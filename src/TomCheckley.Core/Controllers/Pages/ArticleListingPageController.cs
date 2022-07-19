using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Factories;
using TomCheckley.Core.Models.PageTypes;
using TomCheckley.Core.Services;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace TomCheckley.Core.Controllers.Pages
{
    public class ArticleListingPageController : DefaultController
    {
        private const int DEFAULT_AMOUNT_PER_PAGE = 6;
        private readonly IArticleService _articleService;

        public ArticleListingPageController(
            IPageFactory pageFactory,
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor, 
            IUmbracoHelperAccessor umbracoHelperAccessor,
            IArticleService articleService) 
            : base(pageFactory, logger, compositeViewEngine, umbracoContextAccessor, umbracoHelperAccessor)
        {
            _articleService = articleService;
        }

        public override IActionResult Index()
        {
            string page = HttpContext.Request.Query["page"];
            var amountPerPage = CurrentPage.Value<int>("articlesPerPage", fallback: Fallback.ToDefaultValue, defaultValue: DEFAULT_AMOUNT_PER_PAGE);
            var model = new ArticleListingPage(CurrentPage)
            {
                Items = _articleService.GetPaged(CurrentPage.Key, string.IsNullOrWhiteSpace(page) ? 1 : int.Parse(page), amountPerPage)
            };            
            return View(model);
        }
    }
}
