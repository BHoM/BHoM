/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

using System;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Results
{
    [Description("Resulting local deformation in local coordinates along the bar. This is disregarding rigid body motion and/or rotation.")]
    public class BarDeformation : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Local axial deformation.")]
        public double UX { get; set; } = 0.0;

        [Length]
        [Description("Local deformation along the local y-axis. Generally minor axis deformation.")]
        public double UY { get; set; } = 0.0;

        [Length]
        [Description("Local deformation along the local z-axis. Generally major axis deformation.")]
        public double UZ { get; set; } = 0.0;

        [Angle]
        [Description("Localised torsional rotation.")]
        public double RX { get; set; } = 0.0;

        [Angle]
        [Description("Localised rotation around the local y-axis. Generally relates to major axis rotation")]
        public double RY { get; set; } = 0.0;

        [Angle]
        [Description("Localised rotation around the local z-axis. Generally relates to minor axis rotation")]
        public double RZ { get; set; } = 0.0;

        /***************************************************/
    }
}

