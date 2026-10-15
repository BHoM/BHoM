
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.Fragments;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Drophead on a flat slab. THickness is additional to the thickness of the main slab. Material for drophead will be taken from main slab property.")]
    public class Drophead : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Length]
        [Description("Thickness of the drophead. The total thickness of the slab in the drophead zone will be the slab thickness + drophead thickness.")]
        public virtual double Thickness { get; set; } = 0;

        [Length]
        [Description("Extent of the drop head in the local x (primary) direction.")]
        public virtual double XDimension { get; set; } = 0;

        [Length]
        [Description("Extent of the drop head in the local y (secondary) direction.")]
        public virtual double YDimension { get; set; } = 0;

        [Description("Amount of reinforcement in the dropheads. Will be null if handled by the general Reinforcement layout.")]
        public virtual ReinforcementDensity Reinforcement { get; set; } = null;

        /***************************************************/

    }
}


