using System;
using BHoM.Materials;

namespace BHoM.Structural.SectionProperties 
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISteelBoxSection 
    {
        /// <summary>Top flange width</summary>
        double TopFlangeWidth {get; set; }

        /// <summary>Bottom flange width</summary>
        double BottomFlangeWidth { get; set; }

        /// <summary>Section depth (height)</summary>
        double Depth { get; set;}

        /// <summary>Width of the section</summary>
        double Width { get; set; }

        /// <summary>Top flange thickness</summary>
        double TopFlangeThickness { get; set; }

        /// <summary>Bottom flange thickness</summary>
        double BottomFlangeThickness { get; set; }

        /// <summary>Web thickness - left hand side</summary>
        double WebThicknessLeft { get; set; }

        ///<summary>Web thickness - right hand side</summary>
        double WebThicknessRight { get; set; }
    }
}