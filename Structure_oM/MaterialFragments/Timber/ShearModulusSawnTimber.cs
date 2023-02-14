using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class ShearModulusSawnTimber : IShearModulusTimber
    {
        [ShearModulus]
        [Description("Mean shear modulus, G,mean in Eurocode.")]
        public virtual double Mean { get; set; }
    }
}
