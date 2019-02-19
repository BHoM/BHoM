using BH.oM.Base;
using System;
using System.Collections.Generic;
using BH.oM.Architecture.Properties;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Floor : BHoMObject, IHostObject
    {
        public HostObjectProperties HostObjectProperties { get; set; } = new HostObjectProperties();
        public PolyCurve Profile { get; set; } = new PolyCurve();

        /*
        Methods to implement in BHoM_Engine

        //Create

        public static Floor Floor(PolyCurve profile, Material material, double thickness)
        {
            //Add checks
            //Check if Profile is closed PolyCurve

            Floor aFloor = new Floor();
            aFloor.Profile = profile;
            aFloor.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aFloor;
        }

        public static Floor Floor(PolyCurve profile, Material material, double thickness)
        {
            //Add checks

            Floor aFloor = new Floor();
            aFloor.Profile = profile
            aFloor.HostObjectProperties.AddCompoundLayer(material, thickness);

            return aFloor
        }

        public static Floor Floor(PolyCurve profile, HostedObjectProperties hostObjectProperties)
        {
            //Add checks

            Floor aFloor = new Floor()
            {
                Profile = profile,
                HostedObjectProperties = hostObjectProperties
            };

            return aFloor
        }

        */
    }
}
