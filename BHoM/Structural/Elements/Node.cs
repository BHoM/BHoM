using System;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    public class Node : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Position { get; set; } = new Point();

        public Constraint6DOF Constraint { get; set; } = null;


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static implicit operator Node(Point point)
        {
            return new Node { Position = point };
        }

        /***************************************************/
    }
}
    
