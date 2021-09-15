﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

namespace BH.oM.Data.Library
{
    [Description("Level of confidence for the serialized DataSet, outlining both the reliability of the source and the fidelity of the dataset to that source.")]
    public enum Confidence 
    {
        [Description("Default value - assume no fidelity and no source."]
        Undefined,
        [Description("The DataSet may not have a reliable source and/or fidelity to the source has not been tested")]
        VeryLow,
        [Description("The DataSet comes from an unreliable source and matches the source based on initial checks.")]
        Low,
        [Description("The DataSet comes from a reliable source and matches the source based on initial checks.")]
        Medium,
        [Description("The DataSet comes from a reliable source and matches the source based on extensive review.")]
        High,
        [Description("The DataSet comes from a reliable source and matches the source based on extensive review and unit testing.")]
        VeryHigh

    }
}
