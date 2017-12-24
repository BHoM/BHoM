namespace BH.oM.Geometry
{
    public class Circle : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector(0, 0, 1);

        public double Radius { get; set; } = 0;


        /***************************************************/
    }
}
        
