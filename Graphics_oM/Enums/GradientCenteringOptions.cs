/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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

namespace BH.oM.Graphics.Enums
{
    [Description("Either do not centre the range of the gradient, extend the range to be centred around 0, or make 0 the midpoint of the gradient while keeping UpperBound and LowerBound as the ends.")]
    public enum GradientCenteringOptions
    {
        [Description("No change to the gradient range.")]
        None,
        [Description("Make 0 the midpoint of the gradient while keeping UpperBound and LowerBound as the ends.")]
        Asymmetric,
        [Description("Extend range to be centred around 0.")]
        Symmetric
    }
}

