using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;
using System.Linq;


namespace BH.oM.Structural.Elements
{
    [Serializable]
    public class Opening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Edges { get; set; } = new List<ICurve>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Opening() { }

        /***************************************************/

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Opening(IEnumerable<ICurve> edges)
        {
            Edges = edges.ToList();
        }

    }
}


//public Opening(Curve edges)
//{
//    BH.oM.Geometry.Group<Curve> group = new BH.oM.Geometry.Group<Curve>();
//    group.Add(edges);
//    Edges = group;
//}

