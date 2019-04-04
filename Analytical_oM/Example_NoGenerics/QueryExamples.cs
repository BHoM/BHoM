using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Analytical.Elements.NoGen;
using BH.oM.Analytical.ExampleNoGenerics;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.Engine.Analytical
{
    public static partial class Query
    {
        /***************************************************/

        public static double ExternalCircumference(this IPanel panel)
        {
            //return panel.ExternalEdges.Sum(x => x.Curve.Length());
            return 5;
        }

        /***************************************************/

        public static double CalcSomeValueNoGen()
        {
            Panel panel = new Panel();
            //This method will:
            return panel.ExternalCircumference();
        }

        /***************************************************/

    }
}
