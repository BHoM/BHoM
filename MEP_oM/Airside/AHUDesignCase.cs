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
using System.ComponentModel;
using BH.oM.Base;

namespace BH.oM.MEP.Airside
{
    [Description("Boundary conditions for one fixed-order, 100% outdoor-air AHU calculation. Supply flow is entirely outdoor air. Extract conditions are independent declared assumptions, not a predicted space return condition.")]
    public class AHUDesignCase : BHoMObject
    {
        public virtual AirState OutdoorState { get; set; } = null;

        [Description("Outdoor/supply dry-air mass flow, kg dry air/s. Must be positive.")]
        public virtual double SupplyDryAirMassFlowRate { get; set; } = double.NaN;

        [Description("Extract inlet state at recovery. Required only when recovery is included.")]
        public virtual AirState ExtractInletState { get; set; } = null;

        [Description("Extract dry-air mass flow, kg dry air/s. Required and positive when recovery is included. Not inferred from supply flow.")]
        public virtual double? ExtractDryAirMassFlowRate { get; set; } = null;
    }
}
