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

using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.FloorSystem
{
    public class TimberJoistFloor : BHoMObject, IFloorConfiguration, ITimberTertiaryBeamFloorConfiguration, ITimberSlabConfiguration<ConstantThickness>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ConstantThickness Slab { get; set; } = null;

        [Description("SectionProperty for the girder spanning the local X direction")]
        public virtual TimberSection PrimaryBeam { get; set; } = null;

        [Description("SectionProperty for the infill beams spanning the local Y direction")]
        public virtual TimberSection SecondaryBeam { get; set; } = null;

        [Description("SectionProperty for the tertiary beams spanning between secondary beams in the local X direction")]
        public virtual TimberSection TertiaryBeam { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of tertiary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double TertiaryBeamTopLevel { get; set; }

        [Description("Number of infill beams in a panel, counting one edge beam, but not the other.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Description("Number of tertiary beams.")]
        public virtual int NumTertiary { get; set; } = 0;

        /***************************************************/


    }
}

