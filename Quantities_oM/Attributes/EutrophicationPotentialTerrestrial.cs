﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Eutrophication Potential Terrestrial.")]
    public class EutrophicationPotentialTerrestrial : QuantityAttribute
    {
        public override int N { get; } = 1;

        public override string SIUnit { get; } = "mol N eq";
    }
}
