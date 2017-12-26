namespace BH.oM.Geometry
{
    public class Line : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Start { get; set; } = new Point();

        public Point End { get; set; } = new Point();

        public bool Infinite { get; set; } = false;


        /***************************************************/
    }
}


