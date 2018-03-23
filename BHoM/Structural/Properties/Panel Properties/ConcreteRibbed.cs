﻿using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structural.Properties
{
    public class Ribbed : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Thickness { get; set; }

        public Material Material { get; set; }

        public PanelDirection Direction { get; set; } // TODO: Define default values

        public double TotalDepth { get; set; }

        public double StemWidth { get; set; }

        public double Spacing { get; set; }

        public PanelType PanelType { get; set; } = PanelType.Slab;


        /***************************************************/
    }
}
