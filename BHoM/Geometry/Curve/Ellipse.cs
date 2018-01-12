namespace BH.oM.Geometry
{
    public class Ellipse : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Axis1 { get; set; } = new Vector { X = 1.0, Y = 0.0, Z = 0.0 };

        public Vector Axis2 { get; set; } = new Vector { X = 0.0, Y = 1.0, Z = 0.0 };

        public double Radius1 { get; set; } = 0;

        public double Radius2 { get; set; } = 0;


        /***************************************************/
    }
}