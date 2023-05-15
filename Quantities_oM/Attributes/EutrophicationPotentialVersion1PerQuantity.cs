using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Eutrophication Potential for version 1 of list of indicators.")]
    public class EutrophicationPotentialVersion1PerQuantity : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg PO43- eq per unit";
    }
}
