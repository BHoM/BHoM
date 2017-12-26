namespace BH.oM.Geometry
{

    [Serializable]
    public class Extrusion : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; } = new Line();

        public Vector Direction { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };

        public bool Capped { get; set; } = true;


        /***************************************************/
    }
}

