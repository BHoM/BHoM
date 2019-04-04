using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Analytical.Elements;
using BH.oM.Analytical.ExampleGenerics;

namespace BH.Engine.Analytical
{
    public static partial class Query
    {
        /***************************************************/

        public static double ExternalCircumference<TEdge, TOpening>(this IPanel<TEdge, TOpening> panel) where TEdge:IEdge where TOpening:IOpening<TEdge>
        {
            //return panel.ExternalEdges.Sum(x => x.Curve.Length());
            return 5;
        }

        //public static double ExternalCircumference(this Panel panel)
        //{
        //    //return panel.ExternalEdges.Sum(x => x.Curve.Length());
        //    return 5;
        //}

        /***************************************************/

        public static double ExternalCircumference<TNode>(this ILink<TNode> link) where TNode : INode
        {
            //return panel.ExternalEdges.Sum(x => x.Curve.Length());
            return 5;
        }

        /***************************************************/


        public static double ExternalCircumference2(this IPanel<IEdge, IOpening<IEdge>> panel)
        {
            //return panel.ExternalEdges.Sum(x => x.Curve.Length());
            return 5;
        }

        /***************************************************/

        public static double CalcSomeValue()
        {
            Panel panel = new Panel();

            //This method will not work:
            //double val1 = panel.ExternalCircumference2();

            //This method will:
            return panel.ExternalCircumference();
        }

    }
}
