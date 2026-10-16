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
using BH.oM.Physical.Materials;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Floor configuration of steel primary beams (girders) and steel secondary (infill) beams acting compositely with a concrete slab through shear studs.")]
    public class CompositeSteelInfillBeams : BHoMObject, IFloorConfiguration, ISteelFrameConfiguration, IConcreteSlabConfiguration<ISurfaceProperty>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Surface property defining the construction and thickness of the slab.")]
        public virtual ISurfaceProperty Slab { get; set; } = null;

        [Description("Reinforcement of the slab, defined either as an estimated density or as an explicit layout. Can be null if no slab reinforcement is to be accounted for.")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("Section of the primary beams (girders) spanning between columns in the local X direction.")]
        public virtual ISteelSection PrimaryBeam { get; set; } = null;

        [Description("Section of the secondary (infill) beams spanning between the primary beams in the local Y direction.")]
        public virtual ISteelSection SecondaryBeam { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        [Description("Number of secondary (infill) beams in a bay, counting the beam on one edge of the bay but not the one on the opposite edge. Set to zero for no secondary beams.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Length]
        [Description("Thickness of intumescent paint covering exposed primary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        public virtual double IntumescentPaintThicknessPrimary { get; set; }

        [Length]
        [Description("Thickness of intumescent paint covering exposed secondary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        public virtual double IntumescentPaintThicknessSecondary { get; set; }

        [Description("Material of the intumescent paint. Used when computing material takeoffs of the configuration.")]
        public virtual Material IntumescentPaintMaterial { get; set; }

        [Length]
        [Description("Diameter of shear studs in this floor system")]
        public virtual double StudDiameter { get; set; } = 0;

        [Length]
        [Description("Height of shear studs in this floor system")]
        public virtual double StudHeight { get; set; } = 0;

        [Length]
        [Description("Diameter of the head of the shear studs in this floor system")]
        public virtual double StudHeadDiameter { get; set; } = 0;

        [Length]
        [Description("Thickness of the head of the shear studs in this floor system")]
        public virtual double StudHeadThickness { get; set; } = 0;

        [Length]
        [Description("Spacing of shear studs on the girder")]
        public virtual double StudSpacingPrimary { get; set; } = 0;

        [Length]
        [Description("Spacing of shear studs on the infill beams")]
        public virtual double StudSpacingSecondary { get; set; } = 0;

        [Description("Material of the shear studs.")]
        public virtual Steel StudMaterial { get; set; } = null;

        /***************************************************/
    }
}
