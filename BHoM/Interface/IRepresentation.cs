using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public interface IRepresentation : IObject
    {
        Color Colour { get; set; }
    }
}
