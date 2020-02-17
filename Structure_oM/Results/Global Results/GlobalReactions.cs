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
    [Description("Total global reactions for a given Loadcase or LoadCombination.")]
    public class GlobalReactions : StructuralGlobalResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Force]
        [Description("Total force in the global X-direction.")]
        public double FX { get; set; } = 0.0;

        [Force]
        [Description("Total force in the global Y-direction.")]
        public double FY { get; set; } = 0.0;

        [Force]
        [Description("Total force in the global Z-direction.")]
        public double FZ { get; set; } = 0.0;

        [Moment]
        [Description("Total moment about the global X-axis.")]
        public double MX { get; set; } = 0.0;

        [Moment]
        [Description("Total moment about the global Y-axis.")]
        public double MY { get; set; } = 0.0;

        [Moment]
        [Description("Total moment about the global Z-axis.")]
        public double MZ { get; set; } = 0.0;

        /***************************************************/
    }
}

