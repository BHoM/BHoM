/*
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
    [Description("Confidence level of the serialised DataSet, outlining how well trustworthy the data in it is.")]
    public enum Confidence 
    {
        [Description("Default undefined value when the confidence level has not been properly set to the Dataset.")]
        Undefined,
        [Description("Data in the dataset does not come from a well defined source and has not been well tested.")]
        VeryLow,
        [Description("Data in the dataset does not come from a well defined source but has gone through some initial checks.")]
        Low,
        [Description("Data in the dataset comes from a reliable source and has been gone through some initial checks.")]
        Medium,
        [Description("Data in the dataset comes from a reliable source and has been peer reviewed.")]
        High,
        [Description("Data in the dataset comes from a reliable source, has been peer reviewed and has gone through significant unit testing.")]
        VeryHigh

    }
}
