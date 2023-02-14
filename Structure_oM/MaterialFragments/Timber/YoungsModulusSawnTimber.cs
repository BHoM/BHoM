using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class YoungsModulusSawnTimber : IYoungsModulusTimber
    {
        [YoungsModulus]
        [Description("Mean modulus of elasticity parallel bending, Em,0,mean in Eurocode.")]
        public virtual double ParallelMean { get; set; }

        [YoungsModulus]
        [Description("5 percentile modulus of elasticity parallel bending, Em,0,k in Eurocode.")]
        public virtual double ParallelCharacteristic { get; set; }

        [YoungsModulus]
        [Description("Mean modulus of elasticity perpendicular, Em,90,mean in Eurocode.")]
        public virtual double PerpendicularMean { get; set; }
    }
}
