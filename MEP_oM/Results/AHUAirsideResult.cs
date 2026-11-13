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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.Airside;

namespace BH.oM.MEP.Results
{
    [Description("One fixed-order AHU design-case result. Recovery is stored separately from the downstream process list to prevent duplicate accounting. Duties are design air-stream requirements, not selected equipment capacities.")]
    public class AHUAirsideResult : BHoMObject
    {
        public virtual Guid EquipmentId { get; set; } = Guid.Empty;
        public virtual Guid AirsideDefinitionId { get; set; } = Guid.Empty;
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;
        public virtual AirStream OutdoorInlet { get; set; } = null;
        public virtual AirStream FinalSupply { get; set; } = null;

        [Description("Null when recovery is omitted. Not a final exhaust state: no extract fan is modelled.")]
        public virtual AirStream ExtractLeavingRecovery { get; set; } = null;

        public virtual HeatRecoveryResult RecoveryResult { get; set; } = null;

        [Description("Cooling, heating/reheat and fan results, in execution order. Recovery supply process is NOT repeated here; it is in RecoveryResult.SupplyProcess.")]
        public virtual List<AirProcessResult> SupplyProcesses { get; set; }
            = new List<AirProcessResult>();

        [Description("Total supply-side enthalpy change from outdoor inlet to final supply, W; positive into supply air. Includes recovery. Not purchased heating/cooling duty.")]
        public virtual double NetSupplyHeatTransfer { get; set; } = double.NaN;

        [Description("Total supply-side water change, kg/s; positive into supply air. Includes recovery.")]
        public virtual double NetSupplyMoistureTransfer { get; set; } = double.NaN;

        [Description("Final enthalpy change minus sum of individual supply process heat transfers, W.")]
        public virtual double SupplyEnergyBalanceResidual { get; set; } = double.NaN;

        [Description("Final water change minus sum of individual supply process moisture transfers, kg/s.")]
        public virtual double SupplyMoistureBalanceResidual { get; set; } = double.NaN;

        public virtual List<string> CalculationMessages { get; set; }
            = new List<string>();
    }
}
