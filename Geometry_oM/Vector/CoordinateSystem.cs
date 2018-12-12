using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("Cartesian coordinate system. All vectors to be orthogonal unit vectors")]
    public class CoordinateSystem : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector X { get; set; } = Vector.XAxis;

        public Vector Y { get; set; } = Vector.YAxis;

        public Vector Z { get; set; } = Vector.ZAxis;

        public Point Origin { get; set; } = Point.Origin;
        
        /***************************************************/
    }
}
