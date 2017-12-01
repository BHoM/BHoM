using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Space Objects
    /// </summary>
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double AirMovementGain { get; set; } = 0.0;
        public double Area { get; set; } = 0.0;
        public double AirDistrubution { get; set; } = 0.0;
        //public double AreaAZ { get; set; } = 0.0;
        //public double AreaOutdoorAirRa { get; set; } = 0.0;
        //public double BreathingZoneAirFlowVbz { get; set; } = 0.0;
        public double NumberOfPeoplePz { get; set; } = 0.0;
        public double OccupancyCategory { get; set; } = 0.0;
        //public double PeopleOutdoorAirRateRp { get; set; } = 0.0;

         

        

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Space() { }
    }

}