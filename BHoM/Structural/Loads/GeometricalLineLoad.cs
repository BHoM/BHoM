using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    public class GeometricalLineLoad : BHoMObject, ILoad //TODO: Why is it not inheriting from Load ?
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line Location { get; set; } = null; //TODO: Provide default values

        public Vector ForceA { get; set; } = new Vector();

        public Vector ForceB { get; set; } = new Vector();

        public Vector MomentA { get; set; } = new Vector();

        public Vector MomentB { get; set; } = new Vector();

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;

        public Loadcase Loadcase { get; set; } = new Loadcase();


        /***************************************************/
    }
}
