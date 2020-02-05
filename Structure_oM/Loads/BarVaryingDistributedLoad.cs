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

using BH.oM.Structure.Elements;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Loads
{
    [Description("Varying distributed load for bar elements. Can be used to apply force and/or moments.")]
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Distance along the bar between the start node and the start of the loaded region.")]
        public double DistanceFromA { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Direction and magnitude of the force at the start of the loaded region.")]
        public Vector ForceA { get; set; } = new Vector();

        [MomentPerUnitLength]
        [Description("Direction and magnitude of the moment at the start of the loaded region.")]
        public Vector MomentA { get; set; } = new Vector();

        [Length]
        [Description("Distance along the bar between the end node and the end of the loaded region.")]
        public double DistanceFromB { get; set; } = 0;

        [ForcePerUnitLength]
        [Description("Direction and magnitude of the force at the end of the loaded region.")]
        public Vector ForceB { get; set; } = new Vector();

        [MomentPerUnitLength]
        [Description("Direction and magnitude of the moment at the end of the loaded region.")]
        public Vector MomentB { get; set; } = new Vector();


        /***************************************************/
    }
}

