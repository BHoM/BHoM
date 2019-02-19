using BH.oM.Base;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Wall : BHoMObject, IHostObject
    {
        public HostObjectProperties HostObjectProperties { get; set; } = new HostObjectProperties();
        public PolyCurve Profile { get; set; } = new PolyCurve();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Wall Wall(PolyCurve polyCurve, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aWall;
        }

        public static Wall Wall(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.Profile = profile
            aWall.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aWall
        }

        public static Wall Wall(PolyCurve profile, HostObjectProperties hostObjectProperties)
        {
            //Add checks

            Wall aWall = new Wall()
            {
                Profile = profile,
                HostObjectProperties = hostObjectProperties
            };

            return aWall
        }

        public static Wall Wall(ICurve location, double height, HostedObjectProperties hostObjectProperties)
        {
            //Add checks

            //To implement GetProfile method from Location curve and height
            PolyCurve aProfile = GetProfile(location, height)

            Wall aWall = new Wall()
            {
                Profile = aProfile,
                HostObjectProperties = hostObjectProperties
            };

            return aWall
        }

        */
    }
}
