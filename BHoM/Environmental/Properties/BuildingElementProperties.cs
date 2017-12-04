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

        ApertureDescriptionDay;
        ApertureDescriptionNight;
        ApertureProfileDescriptionDay;
        ApertureProfileDescriptionNight;
        ApertureFunctionDay;
        ApertureFunctionNight;
        ApertureOpeningProportionDay;
        ApertureOpeningProportionNight;
        ApertureScheduleDay;
        ApertureScheduleNight;
        BuildingElementAir;
        BuildingElementColor;
        BuildingElementDescription;
        BuildingElementGround;
        BuildingElementGUID;
        BuildingElementInternalShadows;
        BuildingElementMaterial;
        BuildingElementModified;
        BuildingElementThickness;
        BuildingElementTransparent;
        BuildingElementType;
        gValue;
        gValueShading;
        LtValue;
        ThermalConductivity;
        UValue;



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingElementProperties() { }

    }
}
