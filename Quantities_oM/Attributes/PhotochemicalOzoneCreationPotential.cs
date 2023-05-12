using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Quantities.Attributes
{
    [Description("Quantity type for Photochemical Ozone Creation Potential.")]
    public class PhotochemicalOzoneCreationPotential : QuantityAttribute
    {
        public override int M { get; } = 1;

        public override string SIUnit { get; } = "kg NMVOC eq";
    }
}
