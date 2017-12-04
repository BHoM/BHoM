using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Properties
{
    /// <summary>
    /// BUildingElement Properties
    /// </summary>
    
    public class BuildingElementProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ApertureDescriptionDay { get; set; } = "";
        public string ApertureDescriptionNight { get; set; } = "";
        public string ApertureProfileDescriptionDay { get; set; } = "";
        public string ApertureProfileDescriptionNight { get; set; } = "";
        public string ApertureFunctionDay { get; set; } = "";
        public string ApertureFunctionNight { get; set; } = "";
        public double ApertureOpeningProportionDay { get; set; } = 0.0;
        public double ApertureOpeningProportionNight { get; set; } = 0.0;
        public string ApertureScheduleDay { get; set; } = "";
        public string ApertureScheduleNight { get; set; } = "";
        public bool BuildingElementAir { get; set; } = true;
        public string BuildingElementColor { get; set; } = "";
        public string BuildingElementDescription { get; set; } = "";
        public double BuildingElementFrameWidth { get; set; } = 0.0;
        public bool BuildingElementGround { get; set; } = true;
        public string BuildingElementGUID { get; set; } = "";
        public double BuildingElementHeight { get; set; } = 0.0;
        public bool BuildingElementInternalShadows { get; set; } = true;
        public string BuildingElementMaterial { get; set; } = "";
        public bool BuildingElementModified { get; set; } = true;
        public double BuildingElementThickness { get; set; } = 0.0;
        public bool BuildingElementTransparent { get; set; } = true;
        public string BuildingElementType { get; set; } = "";
        public double BuildingElementWidth { get; set; } = 0.0;
        public double gValue { get; set; } = 0.0;
        public double gValueShading { get; set; } = 0.0;
        public double LtValue { get; set; } = 0.0;
        public double ThermalConductivity { get; set; } = 0.0;
        public double UValue { get; set; } = 0.0;



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingElementProperties() { }

    }
}
