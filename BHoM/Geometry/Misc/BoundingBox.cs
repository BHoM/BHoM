using System;

namespace BH.oM.Geometry
{
    public class BoundingBox : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Min { get; set; } = new Point();

        public Point Max { get; set; } = new Point();


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static BoundingBox operator +(BoundingBox a, BoundingBox b)
        {
            return new BoundingBox
            {
                Min = new Point { X = Math.Min(a.Min.X, b.Min.X), Y = Math.Min(a.Min.Y, b.Min.Y), Z = Math.Min(a.Min.Z, b.Min.Z) },
                Max = new Point { X = Math.Max(a.Max.X, b.Max.X), Y = Math.Max(a.Max.Y, b.Max.Y), Z = Math.Max(a.Max.Z, b.Max.Z) }
            };
        }

        /***************************************************/

        public static BoundingBox operator +(BoundingBox box, Vector v)
        {
            return new BoundingBox { Min = box.Min + v, Max = box.Max + v };
        }

        /***************************************************/
    }
}
