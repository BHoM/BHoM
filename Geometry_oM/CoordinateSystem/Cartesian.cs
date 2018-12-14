using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.Geometry.CoordinateSystem
{
    [Description("Cartesian coordinate system. All vectors to be orthogonal unit vectors")]
    public class Cartesian : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector X { get; } = Vector.XAxis;

        public Vector Y { get; } = Vector.YAxis;

        public Vector Z { get; } = Vector.ZAxis;

        public Point Origin { get; set; } = Point.Origin;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Cartesian(Point origin, Vector x, Vector y, Vector z)
        {
            Origin = origin;
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/

        public Cartesian()
        { }

        /***************************************************/
    }
}
