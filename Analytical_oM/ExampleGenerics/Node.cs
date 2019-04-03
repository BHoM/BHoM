using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Analytical.Elements;
using BH.oM.Base;
using BH.oM.Geometry;


namespace BH.oM.Analytical.ExampleGenerics
{
    public class Node : BHoMObject, INode
    {
        Point Position { get; set; }
    }
}
