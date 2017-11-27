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

        public Constraint6DOF Constraint { get; set; } = null;


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
    
