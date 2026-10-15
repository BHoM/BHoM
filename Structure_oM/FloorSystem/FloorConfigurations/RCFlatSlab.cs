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

namespace BH.oM.Structure.FloorSystem
{
    [Description("Floor configuration of a two-way spanning reinforced concrete flat slab of constant thickness supported directly on columns, optionally with dropheads over the columns.")]
    public class RCFlatSlab : BHoMObject, IFloorConfiguration, IConcreteDropheadSlabConfiguration<ConstantThickness>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Surface property defining the construction and thickness of the slab.")]
        public virtual ConstantThickness Slab { get; set; } = null;

        [Description("Reinforcement of the slab, defined either as an estimated density or as an explicit layout. Can be null if no slab reinforcement is to be accounted for.")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("Drophead in the slabs over columns. For a slab without dropheads this will be null.")]
        public virtual Drophead Drophead { get; set; } = null;

        //[Description("Minimum structural bays in the local x direction.")]
        //public virtual int MinBaysX { get; set; } = 0;

        //[Description("Minimum structural bays in the local y direction.")]
        //public virtual int MinBaysY { get; set; } = 0;

        /***************************************************/


    }
}

