using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Serializable] public class BoundingBox : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Min { get; set; } = new Point();

        public Point Max { get; set; } = new Point();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoundingBox() { }

        /***************************************************/

        public BoundingBox(Point min, Point max)
        {
            Min = min;
            Max = max;
        }

        /***************************************************/

        public BoundingBox(Point centre, Vector extent)
        {
            Min = new Point(centre.X - extent.X, centre.Y - extent.Y, centre.Z - extent.Z);
            Max = new Point(centre.X + extent.X, centre.Y + extent.Y, centre.Z + extent.Z);
        }


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static BoundingBox operator +(BoundingBox a, BoundingBox b)
        {
            Point min = new Point(Math.Min(a.Min.X, b.Min.X), Math.Min(a.Min.Y, b.Min.Y), Math.Min(a.Min.Z, b.Min.Z));
            Point max = new Point(Math.Max(a.Max.X, b.Max.X), Math.Max(a.Max.Y, b.Max.Y), Math.Max(a.Max.Z, b.Max.Z));

            return new BoundingBox(min, max);
        }

        /***************************************************/

        public static BoundingBox operator +(BoundingBox box, Vector v)
        {
            return new BoundingBox(box.Min + v, box.Max + v);
        }

    }
}
