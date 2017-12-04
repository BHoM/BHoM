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

        public double ApertureDescriptionDay;
        public double ApertureDescriptionNight;
        public double ApertureProfileDescriptionDay;
        public double ApertureProfileDescriptionNight;
        public double ApertureFunctionDay;
        public double ApertureFunctionNight;
        public double ApertureOpeningProportionDay;
        public double ApertureOpeningProportionNight;
        public double ApertureScheduleDay;
        public double ApertureScheduleNight;
        public double BuildingElementAir;
        public double BuildingElementColor;
        public double BuildingElementDescription;
        public double BuildingElementGround;
        public string BuildingElementGUID;
        public double BuildingElementInternalShadows;
        public double BuildingElementMaterial;
        public double BuildingElementModified;
        public double BuildingElementThickness;
        public double BuildingElementTransparent;
        public double BuildingElementType;
        public double gValue;
        public double gValueShading;
        public double LtValue;
        public double ThermalConductivity;
        public double UValue;



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingElementProperties() { }

    }
}
