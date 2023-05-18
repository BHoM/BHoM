using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for acidification potential per quantity.")]
    public class AcidificationPerQuantity : QuantityAttribute
    {
        public override string SIUnit { get; } = "mol H+ eq per unit";
    }
}
