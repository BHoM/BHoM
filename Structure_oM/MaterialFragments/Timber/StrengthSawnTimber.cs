using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class StrengthSawnTimber : IStrengthTimber
    {

        [Stress]
        [Description("Bending Strength. Tension stress parallel to the grain at failure in bending as calculated from beam equations. Called f_mk in Eurocode.")]
        public virtual double Bending { get; set; }

        [Stress]
        [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called  f_t0k in Eurocode.")]
        public virtual double TensionParallel { get; set; }

        [Stress]
        [Description("Tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called f_t90k in Eurocode.")]
        public virtual double TensionPerpendicular { get; set; }

        [Stress]
        [Description("Compression Parallel Strength. Compression stress parallel to the grain at failure in net compression. Called f_c0k in Eurocode.")]
        public virtual double CompressionParallel { get; set; }

        [Stress]
        [Description("Compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called f_c90k in Eurocode.")]
        public virtual double CompressionPerpendicular { get; set; }

        [Stress]
        [Description("Shear Strength. Shear stress parallel to the grain at failure in net shear, i.e. shear relevant to beam bending. Called f_vk in Eurocode.")]
        public virtual double Shear { get; set; }
    }
}
