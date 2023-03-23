using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for global warming potential.")]
    public class GlobalWarmingPotential : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg CO2eq";
    }
}
