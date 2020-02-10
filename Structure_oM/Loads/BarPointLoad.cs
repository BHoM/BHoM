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
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Geometry;

namespace BH.oM.Structure.Loads
{
    [Description("Point load to be applied for bar elements, positioned a set distance from the start node.")]
    public class BarPointLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Distance along the Bar between the StartNode and the load position.")]
        public double DistanceFromA { get; set; } = 0;

        [Force]
        [Description("Magnitude and direction of the Force. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
        public Vector Force { get; set; } = new Vector();

        [Force]
        [Description("Magnitude and direction of the Moment. The load requires the Force and/or the Moment Vector to be non-zero to have any effect.")]
        public Vector Moment { get; set; } = new Vector();

        /***************************************************/
    }
}

