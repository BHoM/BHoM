using BH.oM.Geometry;
using BH.oM.Base;


namespace BH.oM.Structural.Loads
{
    public class GeometricalAreaLoad : BHoMObject, ILoad  //TODO: Why is it not inheriting from Load ?
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Contour { get; set; }  //TODO: Provide default values

        public Loadcase Loadcase { get; set; } = new Loadcase();

        public Vector Force { get; set; }

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;


        /***************************************************/        
    }
}
