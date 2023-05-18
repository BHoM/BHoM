using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for climate change per quantity.")]
    public class ClimateChangePerQuantity : QuantityAttribute
    {
        public override string SIUnit { get; } = "kg CO2 eq per unit";
    }
}
