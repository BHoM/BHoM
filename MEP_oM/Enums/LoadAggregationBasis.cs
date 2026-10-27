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

 using System.ComponentModel;

namespace BH.oM.MEP.Criteria
{
    [Description("Basis used to aggregate compatible space-load results into a service demand.")]
    public enum LoadAggregationBasis
    {
        [Description("The aggregation basis has not been defined.")]
        Unspecified = 0,

        [Description("Sum of individual room peak demands. This is not a claim of time-coincident demand.")]
        SumOfRoomPeaks = 1,

        [Description("Aggregation of compatible load values at a common timestamp or interval.")]
        CoincidentProfiles = 2
    }
}