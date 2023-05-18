using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Eutrophication Potential Aquatic FreshWater.")]
    public class EutrophicationAquaticFreshwater : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg P eq";
    }
}

