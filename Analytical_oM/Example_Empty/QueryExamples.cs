using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Analytical.Elements.Empty;
using BH.oM.Analytical.ExampleEmpty;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.Engine.Analytical
{
    public static partial class Query
    {
        /***************************************************/

        public static double ExternalCircumferenceEmpty(this IPanel panel)
        {
            //return panel.IExternalEdges().Sum(x => x.ICurve().Length());
            return 5;
        }

        /***************************************************/

        public static double CalcSomeValueEmpty()
        {
            Panel panel = new Panel();
            //This method will:
            return panel.ExternalCircumferenceEmpty();
        }

        /***************************************************/

        public static List<IEdge> IExternalEdges(this IPanel panel)
        {
            return ExternalEdges(panel as dynamic);
        }

        /***************************************************/

        public static List<IEdge> ExternalEdges(this Panel panel)
        {
            return panel.ExternalEdges.Cast<IEdge>().ToList();
        }

        /***************************************************/

        public static ICurve ICurve(this IEdge edge)
        {
            return Curve(edge as dynamic);
        }

        /***************************************************/

        public static ICurve Curve(this Edge edge)
        {
            return edge.Curve;
        }

        /***************************************************/

    }
}
