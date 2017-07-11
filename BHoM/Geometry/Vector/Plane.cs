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
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Plane;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            double x = Normal.X == 0 ? 0 : double.MaxValue;
            double y = Normal.Y == 0 ? 0 : double.MaxValue;
            double z = Normal.Z == 0 ? 0 : double.MaxValue;

            return new BoundingBox(new Point(-x, -y, -z), new Point(x, y, z));
        }

        /***************************************************/

        public object Clone()
        {
            return new Plane(Origin.Clone() as Point, Normal.Clone() as Vector);
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new Plane(Origin+t, Normal.Clone() as Vector);
        }




        ///// <summary>
        ///// Scalar value in the plane equation ax + by + cz + d = 0
        ///// </summary>
        //public double D { get; private set; }

        //public Plane(Point p1, Point p2, Point p3)
        //{
        //    m_Normal = Vector.CrossProduct(p2 - p1, p3 - p1).Normalise();
        //    D = -Vector.DotProduct(Normal, p1);
        //    Origin = p1.Clone() as Point;
        //}

        //public static Plane XY(double z = 0)
        //{
        //    return new Plane(new Point(0,0,z), Vector.ZAxis());
        //}

        //public static Plane YZ(double x = 0)
        //{
        //    return new Plane(new Point(x, 0, 0), Vector.XAxis());
        //}

        //public static Plane XZ(double y = 0)
        //{
        //    return new Plane(new Point(0, y, 0), Vector.YAxis());
        //}



        //public override void Update()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        D -= m_Normal[i] * m_Origin[i];
        //    }
        //}


    }
}
