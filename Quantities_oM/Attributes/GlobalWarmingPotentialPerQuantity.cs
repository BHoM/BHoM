using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for global warming potential per quantity.")]
    public class GlobalWarmingPotentialPerQuantity : QuantityAttribute
    {
        public override string SIUnit { get; } = "kg CO2eq / x";
    }
}
