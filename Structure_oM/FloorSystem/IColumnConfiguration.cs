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
    [Description("Base interface for the configuration of a column designed to support a particular number of stories at a given floor height.")]
    public interface IColumnConfiguration<out T> : IBHoMObject where T: IGeometricalSection
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Section of the column required for this configuration.")]
        T ColumnSection { get; }

        [Length]
        [Description("Floor-to-floor height that the column configuration is designed for.")]
        double FloorHeight { get; }

        [Description("Number of stories supported by the column in this configuration.")]
        int NumberOfStories { get; }

        /***************************************************/
    }
}
