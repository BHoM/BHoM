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
    [Description("Full or explicitly allocated supply from one 100% outdoor-air AHU to one space. Steady declared-state assessment, not room prediction.")]
    public class SpaceAirBalanceResult : BHoMObject
    {
        [Description("Guid.Empty for legacy full-stream balance; otherwise the applied branch allocation ID.")]
        public virtual Guid SupplyAllocationId { get; set; } = Guid.Empty;
        [Description("True for legacy full-stream path. False for explicit branch-allocation path, even for a one-branch set.")]
        public virtual bool UsesFullAHUSupply { get; set; } = true;
        [Description("Delivered branch dry-air mass flow divided by AHU final supply flow.")]
        public virtual double AHUSupplyFraction { get; set; } = double.NaN;

        [Description("Canonical Space.BHoM_Guid.")]
        public virtual Guid SpaceId { get; set; } = Guid.Empty;

        [Description("AHUDesignCase.BHoM_Guid. Required and consistent across connected inputs.")]
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;

        [Description("Criteria snapshot reference.")]
        public virtual Guid CriteriaId { get; set; } = Guid.Empty;

        [Description("Source demand identity.")]
        public virtual Guid DemandId { get; set; } = Guid.Empty;

        [Description("Source AHU result identity.")]
        public virtual Guid AHUResultId { get; set; } = Guid.Empty;

        [Description("Equipment reference; may be unassigned.")]
        public virtual Guid EquipmentId { get; set; } = Guid.Empty;

        [Description("Source airside definition reference.")]
        public virtual Guid AirsideDefinitionId { get; set; } = Guid.Empty;

        [Description("Room design condition used.")]
        public virtual SpaceDesignCondition DesignCondition { get; set; } = SpaceDesignCondition.Unspecified;

        [Description("Independent room-state snapshot.")]
        public virtual AirState RoomDesignState { get; set; } = null;

        [Description("Independent delivered-stream snapshot. For allocated balances contains only this branch flow.")]
        public virtual AirStream DeliveredSupply { get; set; } = null;

        [Description("W; positive heating, negative cooling.")]
        public virtual double SensibleConditioningDemand { get; set; } = double.NaN;

        [Description("W into room; m_da Cp(w_supply) (T_supply - T_room).")]
        public virtual double SupplySensibleContribution { get; set; } = double.NaN;

        [Description("W; demand minus contribution; signed and not clamped.")]
        public virtual double ResidualSensibleDemand { get; set; } = double.NaN;

        [Description("kg/s; NaN means unassessed.")]
        public virtual double MoistureConditioningDemand { get; set; } = double.NaN;

        [Description("kg water/s; m_da (w_supply - w_room).")]
        public virtual double SupplyMoistureContribution { get; set; } = double.NaN;

        [Description("kg water/s; demand minus contribution, NaN when demand unassessed.")]
        public virtual double ResidualMoistureDemand { get; set; } = double.NaN;

        [Description("J/kg water: 2501000 + 1860 T_room. Reporting convention, not a universal latent heat.")]
        public virtual double MoistureEnergyCoefficient { get; set; } = double.NaN;

        [Description("m3/s at room design state; optional requirement explicitly converted by caller.")]
        public virtual double RequiredOutdoorAirFlowAtRoomState { get; set; } = double.NaN;

        [Description("m3/s at room design state; all delivered dry air treated as outdoor air.")]
        public virtual double DeliveredOutdoorAirFlowAtRoomState { get; set; } = double.NaN;

        [Description("Delivered minus required at room state; NaN if unassessed.")]
        public virtual double OutdoorAirFlowMargin { get; set; } = double.NaN;

        [Description("Null means not assessed. Not an overall compliance verdict.")]
        public virtual bool? OutdoorAirRequirementSatisfied { get; set; } = null;

        [Description("Calculation scope and assumptions.")]
        public virtual List<string> CalculationMessages { get; set; } = new List<string>();

    }
}
