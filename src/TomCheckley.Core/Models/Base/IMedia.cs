using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.Models.Base
{
    public interface IMedia
    {
        string Name { get; }
        double Size { get; }
        string Url { get; }
        string AbsoluteUrl { get; }
    }
}
