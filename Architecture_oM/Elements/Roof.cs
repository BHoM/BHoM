using BH.oM.Base;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Roof : BHoMObject, IObject2D
    {
        public Object2DProperties Properties { get; set; } = new Object2DProperties();
        public ISurface Surface { get; set; } = new NurbsSurface();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Roof Roof(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Roof aRoof = new Roof();
            aRoof.Surface = Create.NurbsSurface(Query.IControlPoints(profile));;
            aRoof.Properties.AddCompoundLayer(material, thickness);

            return aRoof;
        }

        public static Roof Roof(PolyCurve profile, Object2DProperties properties)
        {
            //Add checks

            Roof aRoof = new Roof()
            {
                Surface = Create.NurbsSurface(Query.IControlPoints(profile)),
                Properties = properties
            };

            return aRoof
        }

        */
    }
}
