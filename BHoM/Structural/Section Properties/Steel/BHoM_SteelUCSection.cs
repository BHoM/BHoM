using System;
using BHoM.Materials;

namespace BHoM.Structural.SectionProperties 
{
    /// <summary>
    /// 
    /// </summary>
    public class SteelUCSection : SectionProperty
    {
        /// <summary>Top flange width</summary>
        public double TopFlangeWidth {get; set; }

        /// <summary>Bottom flange width</summary>
        public double BottomFlangeWidth { get; set; }

        /// <summary>Section depth (height)</summary>
        public double Depth { get; set;}

        /// <summary>Top flange thickness</summary>
        public double TopFlangeThickness { get; set; }

        /// <summary>Bottom flange thickness</summary>
        public double BottomFlangeThickness { get; set; }

        /// <summary>Web thickness</summary>
        public double WebThickness { get; set; }

        ///<summary>Root radius</summary>
        public double RootRadius { get; set; }
    }
}