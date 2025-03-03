/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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

using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment
{
    public enum LifeCycleAssessmentModule
    {
        Undefined,
        [Description("Metric relating to the Raw Material Supply module in the Product stage.")]
        A1,
        [Description("Metric relating to the Transport module in the Product stage.")]
        A2,
        [Description("Metric relating to the Manufacturing module in the Product stage.")]
        A3,
        [Description("Metric relating to the full Product stage.")]
        A1toA3,
        [Description("Metric relating to the Transport module in the Construction Process stage.")]
        A4,
        [Description("Metric relating to the Construction Installation Process module in the Construction Process stage.")]
        A5,
        [Description("Metric relating to the Use module in the Use stage.")]
        B1,
        [Description("Metric relating to the Maintenance module in the Use stage.")]
        B2,
        [Description("Metric relating to the Repair module in the Use stage.")]
        B3,
        [Description("Metric relating to the Replacement module in the Use stage.")]
        B4,
        [Description("Metric relating to the Refurbishment module in the Use stage.")]
        B5,
        [Description("Metric relating to the Operational Energy Use module in the Use stage.")]
        B6,
        [Description("Metric relating to the Operational Water Use module in the Use stage.")]
        B7,
        [Description("Metric relating to the full Use Stage.")]
        B1toB7,
        [Description("Metric relating to the De-construction Demolition module in the End of Life stage.")]
        C1,
        [Description("Metric relating to the Transport module in the End of Life stage.")]
        C2,
        [Description("Metric relating to the Waste Processing module in the End of Life stage.")]
        C3,
        [Description("Metric relating to the Disposal module in the End of Life stage.")]
        C4,
        [Description("Metric relating to the full End of Life stage.")]
        C1toC4,
        [Description("Metric relating to benefits and loads beyond the system boundary.")]
        D,
    }
}





