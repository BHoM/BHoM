using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Databases
{
    public enum SteelSectionData
    {
        /// <summary>
        /// ID
        /// </summary>
        Id = 0,
        /// <summary>
        /// Section type (ie UC, UB)
        /// </summary>
        Type,
        /// <summary>
        /// Shape type 
        /// </summary>
        Shape,
        /// <summary>
        /// Mass
        /// </summary>
        Mass,
        /// <summary>
        /// Total Height
        /// </summary>
        Height,
        /// <summary>
        /// total width
        /// </summary>
        Width,
        /// <summary>
        /// Custom dimension, usually corresponds with top flange width
        /// </summary>
        B1,
        /// <summary>
        /// Custom dimension, usually corresponds with bottom flange width
        /// </summary>
        B2,
        /// <summary>
        /// custom dimension
        /// </summary>
        B3,
        /// <summary>
        /// plate thickness of web
        /// </summary>
        TW,
        /// <summary>
        /// Plate thickness of top flange
        /// </summary>
        TF1,
        /// <summary>
        /// thickness of bot flange
        /// </summary>
        TF2,
        /// <summary>
        /// Radius 1 - web/flange radius in Tee/ISection/angle or outer radius in box/rectangular sections
        /// </summary>
        r1,
        /// <summary>
        /// Radius 2 - toe or inner radius
        /// </summary>
        r2,
        /// <summary>
        /// Spacing between double section members
        /// </summary>
        Spacing
    }

    public enum CableSectionData
    {
        /// <summary>
        /// Id
        /// </summary>
        Id = 0,
        /// <summary>
        /// Diameter[m]
        /// </summary>
        D,
        /// <summary>
        /// Breaking Load [N]
        /// </summary>
        BL,
        /// <summary>
        /// Limit tension [N]
        /// </summary>
        LimTen,
        /// <summary>
        /// Area [m2]
        /// </summary>
        A,
        /// <summary>
        /// Weight per meter [kg/m]
        /// </summary>
        Weight,
        /// <summary>
        /// Axial stiffness [N]
        /// </summary>
        Stiffness,
        /// <summary>
        /// Construction
        /// </summary>
        Construction,
        /// <summary>
        /// Selfweight open spelter fork end termination [kg]
        /// </summary>
        WeightEndOpen,
        /// <summary>
        /// Selfweight adjustable spelter fork end termination [kg]
        /// </summary>
        WeightEndAdjustable,
        /// <summary>
        /// Name of the cable
        /// </summary>
        Name,
    }
}
