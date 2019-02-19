using BH.oM.Base;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Wall : BHoMObject, IHostObject
    {
        public HostedObjectProperties HostedObjectProperties { get; set; } = new HostedObjectProperties();
        public PolyCurve Profile { get; set; } = new PolyCurve();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Wall Wall(PolyCurve polyCurve, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.HostedObjectProperties.AddCompoundLayer(material, thickness);

            return aWall;
        }

        public static Wall Wall(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.Profile = profile
            aWall.HostedObjectProperties.AddCompoundLayer(material, thickness);

            return aWall
        }

        public static Wall Wall(PolyCurve profile, HostedObjectProperties hostedObjectProperties)
        {
            //Add checks

            Wall aWall = new Wall()
            {
                Profile = profile,
                HostedObjectProperties = hostedObjectProperties
            };

            return aWall
        }

        public static Wall Wall(ICurve location, double height, HostedObjectProperties hostedObjectProperties)
        {
            //Add checks

            //To implement GetProfile method from Location curve and height
            PolyCurve aProfile = GetProfile(location, height)

            Wall aWall = new Wall()
            {
                Profile = aProfile,
                HostedObjectProperties = hostedObjectProperties
            };

            return aWall
        }

        */
    }
}
