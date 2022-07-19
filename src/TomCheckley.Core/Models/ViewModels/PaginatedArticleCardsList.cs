using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.Base;
using TomCheckley.Core.Models.Cards;

namespace TomCheckley.Core.Models.ViewModels
{
    public class PaginatedArticleCardsList : PaginatedList<ArticleCard>
    {
        public string BaseUrl { get; set; }
    }
}
