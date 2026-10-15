using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Physical.Materials;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.FloorSystem
{
    public interface ISteelFrameConfiguration : ISecondaryBeamConfiguration<ISteelSection, ISteelSection>
    {

        [Length]
        [Description("Thickness of intumescent paint covering exposed primary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        double IntumescentPaintThicknessPrimary { get; set; }

        [Length]
        [Description("Thickness of intumescent paint covering exposed secondary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        double IntumescentPaintThicknessSecondary { get; set; }

        [Description("Material of the instumescent paint.")]
        Material IntumescentPaintMaterial { get; set; }

    }
}
