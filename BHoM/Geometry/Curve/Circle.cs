namespace BH.oM.Geometry
{
    [Serializable]
    public class Circle : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Centre { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };

        public double Radius { get; set; } = 0;


        /***************************************************/
    }
}

