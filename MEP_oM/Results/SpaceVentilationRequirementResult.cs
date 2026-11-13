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
    [Description("Space ventilation requirement interpreted at an explicit room reference state; not regulatory compliance or thermal supply sizing.")]
    public class SpaceVentilationRequirementResult : BHoMObject
    {
        public virtual Guid SpaceId { get; set; } = Guid.Empty;
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;
        public virtual Guid CriteriaId { get; set; } = Guid.Empty;
        public virtual SpaceDesignCondition DesignCondition { get; set; } = SpaceDesignCondition.Unspecified;
        public virtual AirState ReferenceState { get; set; }
        [Description("Required outdoor-air volume at ReferenceState, m3/s. Zero is deliberate.")]
        public virtual double RequiredOutdoorAirFlowAtRoomState { get; set; } = double.NaN;
        [Description("Specific volume, m3/kg dry air, at ReferenceState.")]
        public virtual double ReferenceSpecificVolume { get; set; } = double.NaN;
        [Description("Required dry-air mass flow, kg/s.")]
        public virtual double RequiredDryAirMassFlowRate { get; set; } = double.NaN;
        public virtual string SourceResultCase { get; set; } = "";
        public virtual string Basis { get; set; } = "";
        public virtual List<string> CalculationMessages { get; set; } = new List<string>();
    }
}
