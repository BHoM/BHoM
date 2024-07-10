using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.Elements
{
    public class Stem : BHoMObject, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Location surface defining the stem.")]
        public virtual PolyCurve Outline { get; set; } = null;

        [Description("Thickness at the top of the stem.")]
        public virtual double ThicknessTop { get; set; } = 0.0;

        [Description("Thickness at the base of the stem.")]
        public virtual double ThicknessBottom { get; set; } = 0.0;

        [Description("Vector denoting the normal out of the retained plane.")]
        public virtual Vector Orientation { get; set; } = null;

        [Description("Structural material of the property.")]
        public virtual IMaterialFragment Material { get; set; } = null;


        /***************************************************/

    }
}
