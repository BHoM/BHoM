/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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

using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using System.Collections.Generic;
using BH.oM.Analytical.Elements;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// BH.oM panel class - a planar surface object with a list of 'edges' (curves with properties) for both external and internal edges (openings)
    /// </summary>
    public class Panel : Base.BHoMObject, IAreaElement, IElement2D, IPanel<Edge,Opening>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Edge> ExternalEdges { get; set; } = new List<Edge>();

        public List<Opening> Openings { get; set; } = new List<Opening>();

        public ISurfaceProperty Property { get; set; } = new ConstantThickness();      


        /***************************************************/ 
    }
}
       