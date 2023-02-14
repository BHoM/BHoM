using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class YoungsModulusGlulam : IYoungsModulusTimber
    {
        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel bending, E0,g,mean in Eurocode.")]
        public virtual double ParallelMean { get; set; }

        [YoungsModulus]
        [Description("5 percentile modulus of elasticity parallel bending, E0,g,05 in Eurocode.")]
        public virtual double ParallelCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, E90,g,mean in Eurocode.")]
        public virtual double PerpendicularMean { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, E90,g,05 in Eurocode.")]
        public virtual double PerpendicularCharacteristic { get; set; }
    }
}
