/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

namespace BH.oM.Structure.SectionProperties.Reinforcement
{
    [Description("A region defining the area of a Panel to be reinforced.")]
    public class ReinforcementRegion : BHoMObject, IRegion
    {
        [Description("Local x, y, and z axes of the region as a vector Basis. Defaults to world axes.")]
        public virtual Basis Orientation { get; set; } = Basis.XY;

        [Description("A 2D curve defining the external boundaries of the region to be reinforced.")]
        public virtual ICurve Perimeter { get; set; } = new Polyline();
    }

}
