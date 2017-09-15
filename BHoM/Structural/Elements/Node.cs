using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;
using BH.oM.Structural.Loads;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Node objects
    /// </summary>
    [Serializable]
    public class Node : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Point { get; set; } = new Point();

        public NodeConstraint Constraint { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Node() { }

        /***************************************************/

        public Node(Point point, string name = "")
        {
            Point = new Point(point.X, point.Y, point.Z);
            Name = name;
        }

    }
}



        ///***************************************************/
        ///**** Override BHoMObject                       ****/
        ///***************************************************/

        //TODO: Where does this go? o we actually have a weight defined anymore

        //public Node Merge(Node n)
        //{
        //    if (this.Constraint == null)
        //    {
        //        this.Constraint = n.Constraint;
        //    }

        //    this.Point = new Point(this.X + n.X * n.m_Weight, this.Y + n.Y * n.m_Weight, this.Z + n.Z * n.m_Weight) / (1 + n.m_Weight);
        //    this.m_Weight = n.m_Weight + 1;
        //    return this;
        //}

        //#endregion

        //#region Static Methods
        //public static List<Node> MergeWithin(List<Node> nodes, double tolerance)
        //{
        //    int removed = 0;
        //    List<Node> result = new List<Node>();
        //    nodes.Sort(delegate (Node n1, Node n2)
        //    {
        //        return n1.Point.DistanceTo(BH.oM.Geometry.Point.Origin).CompareTo(n2.Point.DistanceTo(BH.oM.Geometry.Point.Origin));
        //    });
        //    result.AddRange(nodes);

        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        double distance = nodes[i].Point.DistanceTo(BH.oM.Geometry.Point.Origin);
        //        int j = i + 1;
        //        while (j < nodes.Count && Math.Abs(nodes[j].Point.DistanceTo(BH.oM.Geometry.Point.Origin) - distance) < tolerance)
        //        {
        //            if (nodes[i].Point.DistanceTo(nodes[j].Point) < tolerance)
        //            {
        //                nodes[j] = nodes[j].Merge(nodes[i]);
        //                result.RemoveAt(i - removed++);
        //                break;
        //            }
        //            j++;
        //        }
        //    }
        //    return result;
        //}
        //#endregion

        // move over to engine without weights if possible
        //#region Fields

        //#endregion
//    }
//}
    
