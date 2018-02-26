using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    public class GeometricalLineLoad : BHoMObject, ILoad //TODO: Why is it not inheriting from Load ?
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line Location { get; set; }  //TODO: Provide default values

        public Vector ForceA { get; set; }

        public Vector ForceB { get; set; }

        public Vector MomentA { get; set; }

        public Vector MomentB { get; set; }

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;

        public Loadcase Loadcase { get; set; } = new Loadcase();


        /***************************************************/
    }
}
