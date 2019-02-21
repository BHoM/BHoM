using BH.oM.Base;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Wall : BHoMObject, IObject2D
    {
        public Object2DProperties Properties { get; set; } = new Object2DProperties();
        public ISurface Surface { get; set; } = new NurbsSurface();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Wall Wall(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Wall aWall = new Wall();
            aWall.Surface = Create.NurbsSurface(Query.IControlPoints(profile));
            aWall.Properties.AddCompoundLayer(material, thickness);

            return aWall
        }

        public static Wall Wall(PolyCurve profile, Object2DProperties properties)
        {
            //Add checks

            Wall aWall = new Wall()
            {
                Profile = profile,
                Properties = properties
            };

            return aWall
        }

        public static Wall Wall(ICurve location, double height, Object2DProperties properties)
        {
            //Add checks

            //To implement GetProfile method from Location curve and height
            ISurface aSurface = GetSurface(location, height)

            Wall aWall = new Wall()
            {
                Surface = aSurface,
                Properties = properties
            };

            return aWall
        }

        */
    }
}
