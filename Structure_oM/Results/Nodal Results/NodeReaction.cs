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
    [Description("Resulting reaction forces and moments for a single Node.")]
    public class NodeReaction : NodeResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Force]
        [Description("Reaction force in x-direction as defined by orientation basis")]
        public double FX { get; set; } = 0.0;

        [Force]
        [Description("Reaction force in y-direction as defined by orientation basis")]
        public double FY { get; set; } = 0.0;

        [Force]
        [Description("Reaction force in z-direction as defined by orientation basis")]
        public double FZ { get; set; } = 0.0;

        [Moment]
        [Description("Moment around the x-axis as defined by orientation basis")]
        public double MX { get; set; } = 0.0;

        [Moment]
        [Description("Moment around the y-axis as defined by orientation basis")]
        public double MY { get; set; } = 0.0;

        [Moment]
        [Description("Moment around the z-axis as defined by orientation basis")]
        public double MZ { get; set; } = 0.0;

        /***************************************************/
    }
}

