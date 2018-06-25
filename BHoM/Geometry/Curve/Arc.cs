using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("Arc starting from the local x, rotating Angle number of radians counter clockwise")]
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public CoordinateSystem CoordinateSystem { get; set; } = null;

        public double Radius { get; set; } = 0;

        [Description("Angle in radians")]
        public double Angle { get; set; } = 0;

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Circle(Arc arc)
        {
            return new Circle { Centre = arc.CoordinateSystem.Origin, Normal = arc.CoordinateSystem.Z, Radius = arc.Radius };
        }

        /***************************************************/
    }
}



