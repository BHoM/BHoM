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

    public enum CableSTFConnectorData
    {
        /// <summary>
        /// Id
        /// </summary>
        Id = 0,
        /// <summary>
        /// Diameter[m]
        /// </summary>
        CableDiameter,
        /// <summary>
        /// Name
        /// </summary>
        Name,
        /// <summary>
        /// Dimmension1[m]
        /// </summary>
        L1,
        /// <summary>
        /// Dimmension2[m]
        /// </summary>
        L2,
        /// <summary>
        /// Dimmension3[m]
        /// </summary>
        L3,
        /// <summary>
        /// Dimmension4[m]
        /// </summary>
        L4,
        /// <summary>
        /// Dimmension5[m]
        /// </summary>
        L5,
        /// <summary>
        /// Dimmension6 Maximum[m]
        /// </summary>
        L6Max,
        /// <summary>
        /// Dimmension6 Minimum[m]
        /// </summary>
        L6Min,
        /// <summary>
        /// Pin Diameter[m]
        /// </summary>
        PinDia,
        /// <summary>
        /// Weight of the socket[kg]
        /// </summary>
        SocketWeight,
        /// <summary>
        /// Weight of the pin + caps[kg]
        /// </summary>
        PinOCapsWeight,
    }

    public enum CableSTAFConnectorData
    {
        /// <summary>
        /// Id
        /// </summary>
        Id = 0,
        /// <summary>
        /// Diameter[m]
        /// </summary>
        CableDiameter,
        /// <summary>
        /// Name
        /// </summary>
        Name,
        /// <summary>
        /// Dimmension1 Max[m]
        /// </summary>
        L1Max,
        /// <summary>
        /// Dimmension1 Min[m]
        /// </summary>
        L1Min,
        /// <summary>
        /// +- Adjustment[m]
        /// </summary>
        Adj,
        /// <summary>
        /// Dimmension3[m]
        /// </summary>
        L3,
        /// <summary>
        /// Dimmension4[m]
        /// </summary>
        L4,
        /// <summary>
        /// Dimmension5[m]
        /// </summary>
        L5,
        /// <summary>
        /// Dimmension6 Maximum[m]
        /// </summary>
        L6Max,
        /// <summary>
        /// Dimmension6 Minimum[m]
        /// </summary>
        L6Min,
        /// <summary>
        /// Pin Diameter[m]
        /// </summary>
        PinDia,
        /// <summary>
        /// Socket Diameter[m]
        /// </summary>
        SocketDia,
        /// <summary>
        /// Thread size
        /// </summary>
        ThreadSize,
        /// <summary>
        /// Weight [kg]
        /// </summary>
        Weight
    }

    public enum CableSTRCConnectorData
    {
        /// <summary>
        /// Id
        /// </summary>
        Id = 0,
        /// <summary>
        /// Diameter[m]
        /// </summary>
        CableDiameter,
        /// <summary>
        /// Name
        /// </summary>
        Name,
        /// <summary>
        /// Dimmension2 Max[m]
        /// </summary>
        L2Max,
        /// <summary>
        /// Dimmension2 Min[m]
        /// </summary>
        L2Min,
        /// <summary>
        /// +- Adjustment[m]
        /// </summary>
        Adj,
        /// <summary>
        /// Dimmension3[m]
        /// </summary>
        SocketDia,
        /// <summary>
        /// Thread size
        /// </summary>
        ThreadSize,
        /// <summary>
        /// Weight [kg]
        /// </summary>
        Weight
    }
}
