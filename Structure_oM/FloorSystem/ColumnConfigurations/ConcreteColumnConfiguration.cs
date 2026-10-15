using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.Fragments;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Column data for a required concrete column for supporting a particular floor number of floors for a set height.")]
    public class ConcreteColumnConfiguration : BHoMObject, IColumnConfiguration<ConcreteSection>
    {
        [Description("Section type for the particular column configuration.")]
        public virtual ConcreteSection ColumnSection { get; set; }

        [Description("Amount of reinforcement in the Column.")]
        public virtual ReinforcementDensity Reinforcement { get; set; } = null;

        [Length]
        [Description("Floor height for the configuration.")]
        public virtual double FloorHeight { get; set; }

        [Description("Number of stories the particular column is supporting")]
        public virtual int NumberOfStories { get; set; }
    }
}
