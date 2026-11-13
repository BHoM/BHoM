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
    [Description("Sum of explicit allocated contributions, not raw room gains. Distinct from HVACServiceLoadResult; no factors or equipment selection.")]
    public class ServiceGroupThermalDutyResult : BHoMObject
    {
        [Description("Group identity.")]
        public virtual Guid ServiceGroupId { get; set; } = Guid.Empty;

        [Description("Single assessed case.")]
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;

        [Description("Heating or cooling.")]
        public virtual ThermalDutyKind DutyKind { get; set; } = ThermalDutyKind.Unspecified;

        [Description("Contributions included.")]
        public virtual List<Guid> ContributionIds { get; set; } = new List<Guid>();

        [Description("Total W. Caller verifies complete contributor set.")]
        public virtual double Duty { get; set; } = double.NaN;

        [Description("Scope and completeness limitations.")]
        public virtual List<string> CalculationMessages { get; set; } = new List<string>();

    }
}
