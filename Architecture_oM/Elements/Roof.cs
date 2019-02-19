using BH.oM.Base;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Roof : BHoMObject, IHostObject
    {
        public HostObjectProperties HostObjectProperties { get; set; } = new HostObjectProperties();
        public PolyCurve Profile { get; set; } = new PolyCurve();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Roof Roof(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Roof aRoof = new Roof();
            aRoof.Profile = profile;
            aRoof.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aRoof;
        }

        public static Roof Roof(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Roof aRoof = new Roof();
            aRoof.Profile = profile
            aRoof.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aRoof
        }

        public static Roof Roof(PolyCurve profile, HostObjectProperties hostObjectProperties)
        {
            //Add checks

            Roof aRoof = new Roof()
            {
                Profile = profile,
                HostObjectProperties = hostObjectProperties
            };

            return aRoof
        }

        */
    }
}
