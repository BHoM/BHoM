using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("Cartesian coordinate system. All vectors to be orthogonal unit vectors")]
    public class CoordinateSystem : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector X { get; } = Vector.XAxis;

        public Vector Y { get;} = Vector.YAxis;

        public Vector Z { get;} = Vector.ZAxis;

        public Point Orgin { get; set; } = Point.Origin;

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public CoordinateSystem(Vector x, Vector y, Vector z, Point orgin)
        {
            X = x;
            Y = y;
            Z = z;
            Orgin = orgin;
        }

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Plane(CoordinateSystem coordinateSystem)
        {
            return new Plane { Origin = coordinateSystem.Orgin, Normal = coordinateSystem.Z };
        }

        /***************************************************/
    }
}
