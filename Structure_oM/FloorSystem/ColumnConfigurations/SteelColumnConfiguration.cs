using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Physical.Materials;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Column data for a required steel column for supporting a particular floor number of floors for a set height.")]
    public class SteelColumnConfiguration : BHoMObject, IColumnConfiguration<SteelSection>
    {
        [Description("Section type for the particular column configuration.")]
        public virtual SteelSection ColumnSection { get; set; }

        [Length]
        [Description("Floor height for the configuration.")]
        public virtual double FloorHeight { get; set; }

        [Description("Number of stories the particular column is supporting")]
        public virtual int NumberOfStories { get; set; }

        [Length]
        [Description("Thickness of intumescent paint covering exposed steelwork. Allowance used for when computing takeoffs of the configuration.")]
        public virtual double IntumescentPaintThickness { get; set; }

        [Description("Material of the instumescent paint.")]
        public virtual Material IntumescentPaintMaterial { get; set; }
    }
}
