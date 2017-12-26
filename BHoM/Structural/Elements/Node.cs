using System;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;

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

        public Constraint6DOF Constraint { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Node() { }

        /***************************************************/

        public Node(Point point, string name = "")
        {
            Point = new Point { X = point.X, Y = point.Y, Z = point.Z };
            Name = name;
        }

    }
}
    
