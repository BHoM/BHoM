/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment
{
    [Description("Base interface for all envirnmental metrics.")]
    public interface ILifeCycleAssessmentPhaseData : IObject
    {
        [Description("Enum indicating the metric type the object relates to.")]
        EnvironmentalMetrics MetricType { get; }

        [Description("Data relating to the Raw Material Supply module in the Product stage.")]
        double A1 { get; }

        [Description("Data relating to the Transport module in the Product stage.")]
        double A2 { get; }

        [Description("Data relating to the Manufacturing module in the Product stage.")]
        double A3 { get; }

        [Description("Data relating to the full Product stage.")]
        double A1toA3 { get; }

        [Description("Data relating to the Transport module in the Construction Process stage.")]
        double A4 { get; }

        [Description("Data relating to the Construction Installation Process module in the Construction Process stage.")]
        double A5 { get; }

        [Description("Data relating to the Use module in the Use stage.")]
        double B1 { get; }

        [Description("Data relating to the Maintenance module in the Use stage.")]
        double B2 { get; }

        [Description("Data relating to the Repair module in the Use stage.")]
        double B3 { get; }

        [Description("Data relating to the Replacement module in the Use stage.")]
        double B4 { get; }

        [Description("Data relating to the Refurbishment module in the Use stage.")]
        double B5 { get; }

        [Description("Data relating to the Operational Energy Use module in the Use stage.")]
        double B6 { get; }

        [Description("Data relating to the Operational Water Use module in the Use stage.")]
        double B7 { get; }

        [Description("Data relating to the De-construction Demolition module in the End of Life stage.")]
        double C1 { get; }

        [Description("Data relating to the Transport module in the End of Life stage.")]
        double C2 { get; }

        [Description("Data relating to the Waste Processing module in the End of Life stage.")]
        double C3 { get; }

        [Description("Data relating to the Disposal module in the End of Life stage.")]
        double C4 { get; }

        [Description("Data relating to benefits and loads beyond the system boundary.")]
        double D { get; }

    }
}
