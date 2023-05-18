using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Eutrophication Potential Aquatic FreshWater per quantity.")]
    public class EutrophicationAquaticFreshwaterPerQuantity : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg P eq per unit";
    }
}

