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

        //public override BH.oM.Geometry.IBHoMGeometry GetGeometry()
        //{
        //    return Point;
        //}

        ///***************************************************/

        ///// <summary></summary>
        //public override void SetGeometry(IBHoMGeometry geometry)
        //{
        //    if (geometry is Point)
        //    {
        //        Point = geometry as Point;
        //    }
        //}






        ///// <summary>Returns true is node is constrained</summary>
        //public bool IsConstrained()
        //{
        //    return Constraint != null;
        //}

        ///***************************************************/

        //public override string ToString()
        //{
        //    return "Node: " + Point.ToString();
        //}





        ///// <summary>
        ///// Constructes a node from CartesianCoordinates and a name
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="name"></param>
        //public Node(double x, double y, double z, string name = "") : this()
        //{
        //    Point = new Point(x, y, z);
        //    Name = name;
        //}

        ///// <summary>
        ///// Constructes a node from a BHoM point and a name
        ///// </summary>
        ///// <param name="point"></param>
        ///// <param name="name"></param>



        ///// <summary>
        ///// Returns true if node is valid (number less than 0 or position is invalid)
        ///// </summary>
        //public bool IsValid
        //{
        //    get
        //    {
        //        if (!Point.IsValid) { return false; }
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the CartesianCoordinates of the node position
        ///// </summary>
        //public double[] CartesianCoordinates
        //{
        //    get { return Point; }
        //}

        ///// <summary>
        ///// Gets or sets the X value of the node position
        ///// </summary>


        ///// <summary>
        ///// Gets or sets the Y value of the node position
        ///// </summary>


        ///// <summary>
        ///// Gets or sets the Z value of the node position
        ///// </summary>

        //#endregion

        //#region Methods

        ///// <summary></summary>




        ///// <summary>
        ///// Calculates the distance from the input node to this
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>

        ///// <summary>
        ///// Calculates the square distance from the input node to this
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>

        ///// <summary>
        ///// Sets the name of the node
        ///// </summary>
        ///// <param name="name"></param>


        ///// <summary>
        ///// Sets the constraint of a node
        ///// </summary>
        ///// <param name="constraint"></param>



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
    
