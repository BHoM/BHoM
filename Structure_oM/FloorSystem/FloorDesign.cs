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
using BH.oM.Structure.Elements;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Design of a floor bay, combining a floor configuration and its column configurations with the spans, loading and performance data (depth, mass, fire rating, edge condition and design code) the design was developed for.")]
    public class FloorDesign : BHoMObject, IImmutable
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Name of the floor design.")]
        public override string Name { get; set; } = null;

        [Description("Configuration of the floor structure, i.e. the slab and framing, that the design is based on.")]
        public virtual IFloorConfiguration FloorConfiguration { get; } = null;

        [Description("Column data for the columns supporting the floor, giving the column required for different numbers of supported stories.")]
        public virtual ColumnData ColumnConfiguration { get; } = null;

        [Description("Length of the primary beam or local X dimension.")]
        [Length]
        public virtual double SpanX { get; } = 0;

        [Description("Length of the secondary beam or local Y dimension.")]
        [Length]
        public virtual double SpanY { get; } = 0;

        [Description("Uniformly applied super-imposed dead load on the floor area.")]
        [Pressure]
        public virtual double LoadSDL { get; } = 0;

        [Description("Uniformly applied live load on the floor area.")]
        [Pressure]
        public virtual double LoadLL { get; } = 0;

        [Description("Total floor depth from top of slab to bottom of deepest beam.")]
        [Length]
        public virtual double Depth { get; } = 0;

        [Description("Mass of the floor bay per area.")]
        [MassPerUnitArea]
        public virtual double Mass { get; } = 0;

        [Description("Structural fire rating requirement.")]
        [Time]
        public virtual double FireRating { get; } = 0;

        [Description("Position of the floor bay within the floor plate that the design applies to. Defaults to Interior.")]
        public virtual EdgeCondition EdgeCondition { get; } = EdgeCondition.Interior;

        [Description("Structural engineering code to which the floor bay has been designed.")]
        public virtual string DesignCode { get; } = null;

        [Description("Design assumptions and additional information about the design.")]
        public virtual string DesignNotes { get; } = null;

        /***************************************************/
        /****            Public Constructors            ****/
        /***************************************************/

        public FloorDesign(IFloorConfiguration floorConfiguration,
                            ColumnData columnConfiguration,
                            double spanX,
                            double spanY,
                            double loadSDL,
                            double loadLL,
                            double depth,
                            double mass,
                            EdgeCondition edgeCondition,
                            double fireRating,
                            string designCode,
                            string designNotes
                            )
        {
            FloorConfiguration = floorConfiguration;
            ColumnConfiguration = columnConfiguration;
            SpanX = spanX;
            SpanY = spanY;
            LoadSDL = loadSDL;
            LoadLL = loadLL;
            Depth = depth;
            Mass = mass;
            FireRating = fireRating;
            EdgeCondition = edgeCondition;
            DesignCode = designCode;
            DesignNotes = designNotes;
        }

        /***************************************************/


    }
}
