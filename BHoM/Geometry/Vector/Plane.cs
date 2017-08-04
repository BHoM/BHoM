using System;
using System.Collections.Generic;

using BH.oM.Base;

namespace BH.oM.Geometry
{
    /// <summary>
    /// BHoM Plane object
    /// </summary>
    public class Plane : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Origin { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector(0, 0, 1);


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Plane() { }

        /***************************************************/

        public Plane(Point origin, Vector normal)
        {
            Origin = origin;
            Normal = normal;
        }


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static Plane XY = new Plane(new Point(0, 0, 0), Vector.ZAxis);

        /***************************************************/

        public static Plane YZ = new Plane(new Point(0, 0, 0), Vector.XAxis);

        /***************************************************/

        public static Plane XZ = new Plane(new Point(0, 0, 0), Vector.YAxis);

    }
}
