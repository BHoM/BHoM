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
using BH.oM.Base.Attributes;

namespace BH.oM.Structure.Results
{
    /***************************************************/

    [Description("Specifies the type of design check, defining how Action and Resistance are evaluated.")]
    public enum DesignCheckType
    {
        [Description("Capacity check where the design action must not exceed the resistance (Action <= Resistance).")]
        [DisplayText("Capacity")]
        Capacity,

        [Description("Geometric upper bound check where the evaluated response must remain below a specified limit (Action <= Limit).")]
        [DisplayText("Upper bound")]
        UpperBound,

        [Description("Lower bound check where the evaluated response must remain above a specified minimum value (Action >= Resistance).")]
        [DisplayText("Lower bound")]
        LowerBound
    }
    /***************************************************/
}







