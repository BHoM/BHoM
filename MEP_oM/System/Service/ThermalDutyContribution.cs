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

namespace BH.oM.MEP.Systems
{
    [Description("Positive thermal duty assigned to one service group in one case. Caller includes actual AHU coil duties and residual terminals once only.")]
    public class ThermalDutyContribution : BHoMObject
    {
        [Description("Originating calculation result; required.")]
        public virtual Guid SourceResultId { get; set; } = Guid.Empty;

        [Description("Required stable component label within source result, e.g. AHU.CoolingCoil or LocalCooling.")]
        public virtual string SourceComponent { get; set; } = "";

        [Description("Space identity for local duty; empty for central equipment contribution.")]
        public virtual Guid SpaceId { get; set; } = Guid.Empty;

        [Description("Common case ID.")]
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;

        [Description("Resolved target group; empty unresolved.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("Heating or cooling.")]
        public virtual ThermalDutyKind DutyKind { get; set; } = ThermalDutyKind.Unspecified;

        [Description("Finite nonnegative duty in W; no diversity or capacity margin.")]
        public virtual double Duty { get; set; } = double.NaN;

        [Description("True when inherited from an explicit serving-equipment link.")]
        public virtual bool UsedDefaultAssignment { get; set; } = false;

        [Description("Resolution and exclusion messages.")]
        public virtual List<string> CalculationMessages { get; set; } = new List<string>();

    }
}
