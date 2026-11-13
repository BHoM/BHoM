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
using System.ComponentModel;
using BH.oM.Base;
namespace BH.oM.MEP.Airside
{
    [Description("One space branch dry-air flow for one AHU definition and case. Not a duct model or service-responsibility assignment.")]
    public class SpaceSupplyAirAllocation : BHoMObject
    {
        public virtual Guid SpaceId { get; set; } = Guid.Empty;
        public virtual Guid EquipmentId { get; set; } = Guid.Empty;
        public virtual Guid AirsideDefinitionId { get; set; } = Guid.Empty;
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;
        [Description("kg dry air/s. Zero branch is deliberate; positive total AHU flow required.")]
        public virtual double DryAirMassFlowRate { get; set; } = double.NaN;
        [Description("Required allocation basis; e.g. declared branch flow or ventilation-sized.")]
        public virtual string AllocationBasis { get; set; } = "";
        [Description("Optional originating ventilation-requirement result identity.")]
        public virtual Guid VentilationRequirementId { get; set; } = Guid.Empty;
    }
}
