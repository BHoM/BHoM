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
using BH.oM.Physical.Materials;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem.FloorConfigurations
{
    [Description("Hybrid floor configuration of a timber slab supported on timber secondary beams spanning between concrete primary beams.")]
    public class HybridTimberOnConcreteAndTimber : BHoMObject, IFloorConfiguration, IConcretePrimaryBeamConfiguration, ITimberSecondaryBeamConfiguration<ConcreteSection>, ITimberSlabConfiguration<ISurfaceProperty>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Surface property defining the construction and thickness of the slab.")]
        public virtual ISurfaceProperty Slab { get; set; } = null;

        [Description("Section of the primary beams (girders) spanning between columns in the local X direction.")]
        public virtual ConcreteSection PrimaryBeam { get; set; } = null;

        [Description("Section of the secondary (infill) beams spanning between the primary beams in the local Y direction.")]
        public virtual TimberSection SecondaryBeam { get; set; } = null;

        [Description("Number of secondary (infill) beams in a bay, counting the beam on one edge of the bay but not the one on the opposite edge. Set to zero for no secondary beams.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Description("Reinforcement applied to the beams. Can be left null if more detailed reinforcement is applied to the ConcreteSections for Primary beams.")]
        public virtual IBeamReinforcement BeamReinforcement { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        /***************************************************/
    }
}
