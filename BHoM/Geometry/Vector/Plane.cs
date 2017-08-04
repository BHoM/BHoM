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

        public static Plane XY(double z = 0)
        {
            return new Plane(new Point(0, 0, z), Vector.ZAxis());
        }

        public static Plane YZ(double x = 0)
        {
            return new Plane(new Point(x, 0, 0), Vector.XAxis());
        }

        public static Plane XZ(double y = 0)
        {
            return new Plane(new Point(0, y, 0), Vector.YAxis());
        }

    }
}
