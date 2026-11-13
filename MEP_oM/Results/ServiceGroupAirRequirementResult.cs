/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 * The BHoM is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License, or
 * (at your option) any later version.
 * The BHoM is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 * You should have received a copy of the GNU Lesser General Public License
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.Airside;
using BH.oM.MEP.Systems;

namespace BH.oM.MEP.Results
{
    [Description("Sum of space air requirements belonging to one service group and role in one declared case.")]
    public class ServiceGroupAirRequirementResult : BHoMObject
    {
        [Description("Group identity.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("Common design case; caller establishes simultaneity.")]
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;

        [Description("Membership role used.")]
        public virtual ServiceRole ServiceRole { get; set; } = ServiceRole.Unspecified;

        [Description("Exact contributing space IDs.")]
        public virtual List<Guid> SpaceIds { get; set; } = new List<Guid>();

        [Description("Source record IDs.")]
        public virtual List<Guid> SourceRequirementIds { get; set; } = new List<Guid>();

        [Description("Sum kg dry air/s.")]
        public virtual double RequiredOutdoorDryAirMassFlowRate { get; set; } = double.NaN;

        [Description("Sum kg dry air/s. Not an automatic airflow selection.")]
        public virtual double SelectedSupplyDryAirMassFlowRate { get; set; } = double.NaN;

    }
}
