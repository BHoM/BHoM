using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Abiotic depletion potential (ADP) for minerals and metals (non-fossil resources) per quantity.")]
    public class AbioticDepletionPotentialNonFossilPerQuantity : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg Sb eq per unit";
    }
}
