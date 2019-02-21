using BH.oM.Base;
using System;
using System.Collections.Generic;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Floor : BHoMObject, IObject2D
    {
        public Object2DProperties Properties { get; set; } = new Object2DProperties();
        public ISurface Surface { get; set; } = new NurbsSurface();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Floor Floor(PolyCurve profile, Material material, double thickness)
        {
            //Add checks
            //Check if Profile is closed PolyCurve

            Floor aFloor = new Floor();
            aFloor.Surface = Create.NurbsSurface(Query.IControlPoints(profile));
            aFloor.Properties.AddCompoundLayer(material, thickness);

            return aFloor;
        }

        public static Floor Floor(PolyCurve profile, Object2DProperties properties)
        {
            //Add checks

            Floor aFloor = new Floor()
            {
                Profile = Create.NurbsSurface(Query.IControlPoints(profile)),
                Properties = properties
            };

            return aFloor
        }

        */
    }
}
