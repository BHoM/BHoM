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

using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Base interface for framing systems containing primary beams spanning between columns, secondary beams spanning between primary beams and tertiary beams spanning between secondary beams.")]
    public interface ITertiaryBeamConfiguration<out TPrimary, out TSecondary, out TTertiary> : ISecondaryBeamConfiguration<TPrimary, TSecondary>
        where TPrimary : IGeometricalSection
        where TSecondary : IGeometricalSection
        where TTertiary : IGeometricalSection
    {
        [Description("Section of the tertiary beams spanning between the secondary beams.")]
        TTertiary TertiaryBeam { get; }
        [Description("Number of tertiary beams, evenly spaced across the bay in the local Y direction and spanning in the local X direction between the secondary beams.")]
        int NumTertiary { get; set; }

        [Length]
        [Description("Distance from top of slab to top of tertiary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        double TertiaryBeamTopLevel { get; set; }
    }
}
