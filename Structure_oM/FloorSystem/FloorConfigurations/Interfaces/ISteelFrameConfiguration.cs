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
    [Description("Interface for floor configurations with a frame of steel primary beams and steel secondary beams, including the intumescent paint applied to the beams for fire protection.")]
    public interface ISteelFrameConfiguration : ISecondaryBeamConfiguration<ISteelSection, ISteelSection>
    {

        [Length]
        [Description("Thickness of intumescent paint covering exposed primary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        double IntumescentPaintThicknessPrimary { get; set; }

        [Length]
        [Description("Thickness of intumescent paint covering exposed secondary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        double IntumescentPaintThicknessSecondary { get; set; }

        [Description("Material of the intumescent paint. Used when computing material takeoffs of the configuration.")]
        Material IntumescentPaintMaterial { get; set; }

    }
}
