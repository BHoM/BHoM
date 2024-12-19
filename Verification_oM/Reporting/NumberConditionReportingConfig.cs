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

namespace BH.oM.Verification.Reporting
{
    [Description("Config object containing settings for reporting results of checks against numerical value conditions.")]
    public class NumberConditionReportingConfig : ValueConditionReportingConfig
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Text to be used as a label for units expressing the extracted value.")]
        public virtual string UnitLabel { get; set; } = "";

        [Description("Multiplier to be applied to the extracted value prior to reporting.")]
        public virtual double ValueMultiplier { get; set; } = double.NaN;

        [Description("Rounding accuracy to be used when reporting the extracted value.")]
        public virtual double RoundingAccuracy { get; set; } = double.NaN;

        /***************************************************/
    }
}

