using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("Arc starting from the local x, rotating Angle number of radians counter clockwise")]
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public CoordinateSystem CoordinateSystem { get; set; } = new CoordinateSystem();

        public double Radius { get; set; } = 0;

        [Description("Angle in radians to the start point from the local X-axis, counter clowise around the local Z-axis")]
        public double StartAngle { get; set; } = 0;

        [Description("Angle in radians to the end point from the local X-axis, counter clowise around the local Z-axis")]
        public double EndAngle { get; set; } = 0;

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



