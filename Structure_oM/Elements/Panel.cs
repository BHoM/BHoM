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

using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using System.Collections.Generic;
using BH.oM.Analytical.Elements;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    [Description("2D element for structural analysis. " +
                 "\nThe Panel is a planar surface object defined by a list of planar 'Edges' (curves with properties) for both external and internal edges (openings)")]
    public class Panel : Base.BHoMObject, IAreaElement, IElement2D, IPanel<Edge,Opening>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A list of (co)planar Edges defining the external contour and potential constraints of the Panel")]
        public List<Edge> ExternalEdges { get; set; } = new List<Edge>();

        [Description("A list of Openings of the panel. The edges that make up the openings need to all be coplanar with the external edges")]
        public List<Opening> Openings { get; set; } = new List<Opening>();

        [Description("Defines the thickness property and material of the Panel")]
        public ISurfaceProperty Property { get; set; } = new ConstantThickness();      


        /***************************************************/ 
    }
}
       
