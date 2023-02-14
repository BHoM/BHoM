using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    public class StrengthLVLC : IStrengthTimber
    {
        [Stress]
        [Description("Edgewise bending Strength, parallel to the grain. Called fm,0,edge,k in Eurocode.")]
        public virtual double BendingParallelEdge { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, parallel to the grain. Called fm,0,flat,k in Eurocode.")]
        public virtual double BendingParallelFlat { get; set; }

        [Stress]
        [Description("Flatwise, bending Strength, perpendicular to the grain. Called fm,90,flat,k in Eurocode.")]
        public virtual double BendingPerpendicularFlat { get; set; }

        [Stress]
        [Description("Tension Parallel Strength. Tension stress parallel to the grain at failure in net tension. Called ft,0,k in Eurocode.")]
        public virtual double TensionParallel { get; set; }

        [Stress]
        [Description("Edgewise tension Perpendicular Strength. Tension stress perpendicular to the grain at failure in net tension. Called ft,90,edge,k in Eurocode.")]
        public virtual double TensionPerpendicularEdge { get; set; }

        [Stress]
        [Description("Compression Parallel Strength for service class 1. Compression stress parallel to the grain at failure in net compression. Called fc,0,k in Eurocode.")]
        public virtual double CompressionParallelSC1 { get; set; }

        [Stress]
        [Description("Compression Parallel Strength for service class 2. Value may also be applied in Service Class 1 as a conservative value. Compression stress parallel to the grain at failure in net compression. Called fc,0,k in Eurocode.")]
        public virtual double CompressionParallelSC2 { get; set; }

        [Stress]
        [Description("Edgewise compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called fc,90,edge,k in Eurocode.")]
        public virtual double CompressionPerpendicularEdge { get; set; }

        [Stress]
        [Description("Flatwise compression Perpendicular Strength. Compression stress perpendicular to the grain at failure in net compression. Called ƒc,90,flat,k in Eurocode.")]
        public virtual double CompressionPerpendicularFlat { get; set; }

        [Stress]
        [Description("Edgewise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for edgewise shearing. Called fv,0,edge,k in Eurocode.")]
        public virtual double ShearParallelEdge { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength parallel. Shear stress parallel to the grain at failure in net shear for flatwise shearing. Called fv,0,flat,k in Eurocode.")]
        public virtual double ShearParallelFlat { get; set; }

        [Stress]
        [Description("Flatwise Shear Strength perpendicular. Shear stress perpendicular to the grain at failure in net shear for flatwise shearing. Called fv,90,flat,k in Eurocode.")]
        public virtual double ShearPerpendicularFlat { get; set; }
    }
}
