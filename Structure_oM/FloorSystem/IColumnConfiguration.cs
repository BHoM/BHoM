using BH.oM.Base;
using BH.oM.Structure.SectionProperties;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public interface IColumnConfiguration<out T> : IBHoMObject where T: IGeometricalSection
    {
        [Description("Section type for the particular column configuration.")]
        T ColumnSection { get; }

        [Length]
        [Description("Floor height for the configuration.")]
        double FloorHeight { get; }

        [Description("Number of stories the particular column is supporting")]
        int NumberOfStories { get; }
    }
}
