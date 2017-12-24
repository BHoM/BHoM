namespace BH.oM.Geometry
{

    public class Extrusion : ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; } = new Line();

        public Vector Direction { get; set; } = new Vector(0, 0, 1);

        public bool Capped { get; set; } = true;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Extrusion() { }

        /***************************************************/

        public Extrusion(ICurve curve, Vector direction, bool capped = true)
        {
            Curve = curve;
            Direction = direction;
            Capped = capped;
        }
    }
}
      
