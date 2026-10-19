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
using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Options controlling how a floor design is populated as structural elements in space.")]
    public class PopulateOptions : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Output all objects in one plane, best for FE. Defaults to false; objects will be output at their physical elevations.")]
        public virtual bool AtCenterLine { get; set; } = false;

        [Description("Include south primary girder; true by default.")]
        public virtual bool IncludeSGirder { get; set; } = true;

        [Description("Include west secondary girder; true by default.")]
        public virtual bool IncludeWGirder { get; set; } = true;

        [Description("Include north primary girder; false by default.")]
        public virtual bool IncludeNGirder { get; set; } = false;

        [Description("Include east secondary girder; false by default.")]
        public virtual bool IncludeEGirder { get; set; } = false;

        [Description("If true, bar centrelines are offset based on the element they are connecting to. For Primary beams, and secondary end beams, this relates to the column size. For other secondary beams, relates to thickness of Primary beams, and tertiary beams cutoff by secondary beams.")]
        public virtual bool OffsetBarsFromConnectingElements { get; set; } = false;

        [Description("Include Columns; false by default.")]
        public virtual bool IncludeColumns { get; set; } = false;

        [Description("The number of stories that the column data should be evaluated for. If a negative value is provided, the median configuration will be assumed ordered by number of stories.")]
        public virtual int NumberOfStories { get; set; } = -1;

        [Description("The height of a populated column. By default, the value on the picked column configuration will be used.")]
        [Length]
        public virtual double FloorHeight { get; set; } = double.NaN;

        /***************************************************/
    }
}
