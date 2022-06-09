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

using BH.oM.Analytical.Elements;
using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;

namespace BH.oM.Structure.Reinforcement
{
    [Description("A region defining the area of a Panel to be reinforced. The curve must exist within the 2D region outlined by ExternalEdges of the Panel.")]
    public class ReinforcementRegion : BHoMObject, IRegion
    {
        [Description("Local x, y, and z axes of the region as a vector Basis. Defaults to OrientationAngle and Plane of Panel if null or empty.")]
        public virtual Basis Orientation { get; set; } = null;

        [Description("A 2D curve defining the external boundaries of the region to be reinforced. The curve must exist within the ExternalEdges of the Panel. Defaults" +
            "to the Panel perimeter if null or empty.")]
        public virtual ICurve Perimeter { get; set; } = null;
    }

}

