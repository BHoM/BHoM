using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class ShearModulusGlulam : IShearModulusTimber
    {
        [ShearModulus]
        [Description("Mean shear modulus parallel to the grain, Gg,mean in Eurocode.")]
        public virtual double Mean { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus parallel to the grain, Gg,05 in Eurocode.")]
        public virtual double Characteristic { get; set; }

        [ShearModulus]
        [Description("Mean shear modulus parallel to the grain, Gr,g,mean in Eurocode.")]
        public virtual double RollingMean { get; set; }

        [ShearModulus]
        [Description("Characteristic shear modulus parallel to the grain, Gr,g,05 in Eurocode.")]
        public virtual double RollingCharacteristic { get; set; }
    }
}
