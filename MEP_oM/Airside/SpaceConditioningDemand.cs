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

namespace BH.oM.MEP.Airside
{
    [Description("Declared net space requirement before crediting the assessed supply. Not equipment capacity.")]
    public class SpaceConditioningDemand : BHoMObject
    {
        [Description("Canonical Space.BHoM_Guid.")]
        public virtual Guid SpaceId { get; set; } = Guid.Empty;

        [Description("AHUDesignCase.BHoM_Guid. Required and consistent across connected inputs.")]
        public virtual Guid DesignCaseId { get; set; } = Guid.Empty;

        [Description("Selects heating or cooling room criteria.")]
        public virtual SpaceDesignCondition DesignCondition { get; set; } = SpaceDesignCondition.Unspecified;

        [Description("W; positive heating, negative cooling. Zero deliberate; NaN missing.")]
        public virtual double SensibleConditioningDemand { get; set; } = double.NaN;

        [Description("kg water/s; positive addition, negative removal. NaN means moisture demand unassessed.")]
        public virtual double MoistureConditioningDemand { get; set; } = double.NaN;

        [Description("Required provenance/scope. Exclude outdoor-air treatment and do not pre-credit this supply.")]
        public virtual string DemandBasis { get; set; } = "";

        [Description("Optional source calculation identity.")]
        public virtual Guid SourceId { get; set; } = Guid.Empty;

    }
}
