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

using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Results
{
    [Description("Resulting section forces in local coordinates along the bar.")]
    public class BarForce : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Force]
        [Description("Axial/Normal force of the bar. Positive for tension, negative for compression.")]
        public double FX { get; set; } = 0.0;

        [Force]
        [Description("Shear force along the local y-axis. Generally minor axis shear force.")]
        public double FY { get; set; } = 0.0;

        [Force]
        [Description("Shear force along the local z-axis. Generally major axis shear force.")]
        public double FZ { get; set; } = 0.0;

        [Moment]
        [Description("Torsional moment.")]
        public double MX { get; set; } = 0.0;

        [Moment]
        [Description("Bending moment about the local y-axis. Generally major axis bending moment.")]
        public double MY { get; set; } = 0.0;

        [Moment]
        [Description("Bending moment about the local z-axis. Generally minor axis bending moment.")]
        public double MZ { get; set; } = 0.0;

        /***************************************************/
    }
}

