using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.MaterialFragments.EndOfLife
{
    [Description("Factor on the C3 to C4 module for climate change impacts.")]
    public class FossilWasteFactor : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ClimateChangePerQuantity]
        [Description("Waste processing and disposal Climate change Fossil (embodied carbon) factor. Applied to the fossil factors, and also used to compute the totals. Value assumed per mass.")]
        public virtual double C3toC4 { get; set; }

        [Description("Name of the scenario or material wo which this corresponds.")]
        public override string Name { get; set; }
        /***************************************************/
    }
}
