/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *
 *
 * The BHoM is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License, or
 * (at your option) any later version.
 *
 * The BHoM is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.
 */

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
