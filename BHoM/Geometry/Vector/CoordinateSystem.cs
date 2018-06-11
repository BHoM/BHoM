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

        public Point Origin { get; set; } = Point.Origin;

        /***************************************************/
        /**** Constructor                               ****/
        /***************************************************/

        public CoordinateSystem(Vector x, Vector y, Vector z, Point orgin)
        {
            X = x;
            Y = y;
            Z = z;
            Origin = orgin;
        }

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Plane(CoordinateSystem coordinateSystem)
        {
            return new Plane { Origin = coordinateSystem.Origin, Normal = coordinateSystem.Z };
        }

        /***************************************************/
    }
}
