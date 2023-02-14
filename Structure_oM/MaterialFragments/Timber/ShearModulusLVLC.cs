using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class ShearModulusLVLC : IShearModulusTimber
    {
        [ShearModulus]
        [Description("Edgewise mean shear modulus parallel to the grain, G0,edge,mean in Eurocode.")]
        public virtual double EdgeMean { get; set; }

        [ShearModulus]
        [Description("Edgewise characteristic shear modulus parallel to the grain, G0,edge,k in Eurocode.")]
        public virtual double EdgeCharacteristic { get; set; }

        [ShearModulus]
        [Description("Flatwise mean shear modulus parallel to the grain, G0,flat,mean in Eurocode.")]
        public virtual double ParallelFlatMean { get; set; }

        [ShearModulus]
        [Description("Flatwise characteristic shear modulus parallel to the grain, G0,flat,k in Eurocode.")]
        public virtual double ParallelFlatCharacteristic { get; set; }

        [ShearModulus]
        [Description("Flatwise mean shear modulus perpendicular to the grain, G90,flat,mean in Eurocode.")]
        public virtual double PerpendicularFlatMean { get; set; }

        [ShearModulus]
        [Description("Flatwise characteristic shear modulus perpendicular to the grain, G90,flat,k in Eurocode.")]
        public virtual double PerpendicularFlatCharacteristic { get; set; }
    }
}
