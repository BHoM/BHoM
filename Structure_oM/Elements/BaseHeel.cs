using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.Elements
{
    public class BaseHeel : BHoMObject, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("RetainingWallStem object defining the stem.")]
        public virtual PolyCurve Outline { get; set; } = null;

        [Description("Thickness of the base at the toe edge")]
        public virtual double ThicknessHeel { get; set; } = 0.0;

        [Description("Thickness of the base at stem connection")]
        public virtual double ThicknessStem { get; set; } = 0.0;

        [Description("Structural material of the property.")]
        public virtual IMaterialFragment Material { get; set; } = null;

        /***************************************************/

    }
}
