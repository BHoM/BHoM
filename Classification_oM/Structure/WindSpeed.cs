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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.Structure
{
    [Description("The design wind speed of a site, banded in m/s from very low (below 20 m/s) to very high (50 m/s and above).")]
    public enum WindSpeed
    {
        Undefined,
        [DisplayText("Very Low <20m/s")]
        VLow_LessThan20ms,
        [DisplayText("Low 20-30m/s")]
        Low_20to30ms,
        [DisplayText("Medium 30-40m/s")]
        Medium_30to40ms,
        [DisplayText("High 40-50m/s")]
        High_40to50ms,
        [DisplayText("Very High 50+m/s")]
        VHigh_MoreThan50ms,
    }
}
