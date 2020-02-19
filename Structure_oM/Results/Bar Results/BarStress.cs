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
    [Description("Resulting stresses in local coordinates along the bar.")]
    public class BarStress : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Stress]
        [Description("Axial stress induced by an axial force along the Bar axis. Positive for tension, negative for compression.")]
        public double Axial { get; set; } = 0.0;

        [Stress]
        [Description("Shear stress along the local y-axis. Generally minor axis shear stress.")]
        public double ShearY { get; set; } = 0.0;

        [Stress]
        [Description("Shear stress along the local z-axis. Generally major axis shear stress.")]
        public double ShearZ { get; set; } = 0.0;

        [Stress]
        [Description("Stress induced by bending about the local y-axis at the 'uppermost' extreme fiber. Generally the major axis bending stresses in one of the extreme fibers.")]
        public double BendingY_Top { get; set; } = 0.0;

        [Stress]
        [Description("Stress induced by bending about the local y-axis at the 'lowermost' extreme fiber. Generally the major axis bending stresses in one of the extreme fibers.")]
        public double BendingY_Bot { get; set; } = 0.0;

        [Stress]
        [Description("Stress induced by bending about the local z-axis at the 'uppermost' extreme fiber. Generally the minor axis bending stresses in one of the extreme fibers.")]
        public double BendingZ_Top { get; set; } = 0.0;

        [Stress]
        [Description("Stress induced by bending about the local z-axis at the 'lowermost' extreme fiber. Generally the minor axis bending stresses in one of the extreme fibers.")]
        public double BendingZ_Bot { get; set; } = 0.0;

        [Stress]
        [Description("Worst case tensile normal stress from combined axial and bending in two directions.")]
        public double CombAxialBendingPos { get; set; } = 0.0;

        [Stress]
        [Description("Worst case compressive normal stress from combined axial and bending in two directions.")]
        public double CombAxialBendingNeg { get; set; } = 0.0;

        /***************************************************/
    }
}
