using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Ozone Depletion Potential.")]
    public class OzoneDepletionPotential : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg CFC11 eq";
    }
}
