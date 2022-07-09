using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomCheckley.Core.Models.ViewModels;

namespace TomCheckley.Core.Services
{
    public interface INavigationService
    {
        MainNavigation GetMainNav();
    }
}
