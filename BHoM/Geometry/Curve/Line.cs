namespace BH.oM.Geometry
{
    /// <summary>
    /// BH.oM Line object
    /// </summary>
    public class Line : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Start { get; set; } = new Point();

        public Point End { get; set; } = new Point();

        public bool Infinite { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Line() { }

        /***************************************************/

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        /***************************************************/

        public Line(Point start, Vector direction)
        {
            Start = start;
            End = start + direction;
            Infinite = true;
        }

    }
}


