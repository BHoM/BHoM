using System;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SurfaceProperties;

namespace BH.oM.Structure.Elements
{
    public class RTBase : BHoMObject, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("RetainingWallStem object defining the stem.")]
        public virtual PolyCurve Outline { get; set; } = null;

        [Description("Defines the thickness property and material of the Base.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        /***************************************************/

    }
}
