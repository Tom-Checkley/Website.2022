using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCheckley.Core.Models.Base
{
    public interface IImage : IMedia
    {
        string AltText { get; }
        int Height { get; }
        int Width { get; }
    }
}
