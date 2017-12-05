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
        /// SAM properties of BuildingElements (BE) like Roof, Walls, Floor, Windows, Door and Curtain Panles

        public string ApertureDescriptionDay { get; set; } = "";
        public string ApertureDescriptionNight { get; set; } = "";
        public string ApertureProfileDescriptionDay { get; set; } = "";
        public string ApertureProfileDescriptionNight { get; set; } = "";
        public string ApertureFunctionDay { get; set; } = "";
        public string ApertureFunctionNight { get; set; } = "";
        public double ApertureOpeningProportionDay { get; set; } = 0.0;
        public double ApertureOpeningProportionNight { get; set; } = 0.0;

        ///schedule 24 digits 0 or 1
        public string ApertureScheduleDay { get; set; } = "";
        public string ApertureScheduleNight { get; set; } = "";

        //setting defining if BE is Air
        public bool BuildingElementAir { get; set; } = true;

        //color define as Integer
        public string BuildingElementColor { get; set; } = "";

        public string BuildingElementDescription { get; set; } = "";
        public double BuildingElementFrameWidth { get; set; } = 0.0;

        //setting defining if BE is touching ground
        public bool BuildingElementGround { get; set; } = true;

        public string BuildingElementGUID { get; set; } = "";
        public double BuildingElementHeight { get; set; } = 0.0;

        //setting defining if BE should case shadows sued for transparent external BE
        public bool BuildingElementInternalShadows { get; set; } = true;

        public string BuildingElementMaterial { get; set; } = "";
        public bool BuildingElementModified { get; set; } = true;
        public double BuildingElementThickness { get; set; } = 0.0;

        //setting defining if BE is tranparent used for interal and external BE
        public bool BuildingElementTransparent { get; set; } = true;

        //definistion of BE Type recognized by simulation tools
        public string BuildingElementType { get; set; } = "";

        public double BuildingElementWidth { get; set; } = 0.0;
        public double gValue { get; set; } = 0.0;

        //g-value for element including shading
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
