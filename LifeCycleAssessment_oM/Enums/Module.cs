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
    public enum Module
    {
        //Undefined,
        [Description("Raw Material Supply module in the Product stage.")]
        A1,
        [Description("Transport module in the Product stage.")]
        A2,
        [Description("Manufacturing module in the Product stage.")]
        A3,
        [Description("Full Product stage.")]
        A1toA3,
        [Description("Transport module in the Construction Process stage.")]
        A4,
        [Description("Construction Installation Process module in the Construction Process stage.")]
        A5,
        [Description("On-site construction waste part of the Construction Installation Process module in the Construction Process stage.")]
        A5w,
        [Description("Site activities part of the Construction Installation Process module in the Construction Process stage.")]
        A5a,
        [Description("Use module in the Use stage.")]
        B1,
        [Description("Maintenance module in the Use stage.")]
        B2,
        [Description("Repair module in the Use stage.")]
        B3,
        [Description("Use, Maintenance and Repair modules in the Use stage.")]
        B1toB3,
        [Description("Replacement module in the Use stage.")]
        B4,
        [Description("Refurbishment module in the Use stage.")]
        B5,
        [Description("Replacement and Refurbishment modules in the Use stage.")]
        B4toB5,
        [Description("Full Use Stage except operational energy and Water use.")]
        B1toB5,
        [Description("Operational Energy Use module in the Use stage.")]
        B6,
        [Description("Operational Water Use module in the Use stage.")]
        B7,
        [Description("Full Use Stage.")]
        B1toB7,
        [Description("De-construction Demolition module in the End of Life stage.")]
        C1,
        [Description("Transport module in the End of Life stage.")]
        C2,
        [Description("Waste Processing module in the End of Life stage.")]
        C3,
        [Description("Disposal module in the End of Life stage.")]
        C4,
        [Description("Waste Processing and disposal modules in the End of Life stage.")]
        C3toC4,
        [Description("Full End of Life stage.")]
        C1toC4,
        [Description("Benefits and loads beyond the system boundary.")]
        D,
    }
}





