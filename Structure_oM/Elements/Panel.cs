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

using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using System.Collections.Generic;
using BH.oM.Analytical.Elements;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.Elements
{
    [Description("2D element for structural analysis. " +
                 "\nThe Panel is a planar surface object defined by a list of planar 'Edges' (curves with properties) for both external and internal edges (openings).")]
    public class Panel : Base.BHoMObject, IAreaElement, IElement2D, IPanel<Edge,Opening>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A list of coplanar Edges defining the external contour and potential constraints of the Panel.")]
        public virtual List<Edge> ExternalEdges { get; set; } = new List<Edge>();

        [Description("A list of Openings of the panel. The edges that make up the openings must be coplanar with the external edges.")]
        public virtual List<Opening> Openings { get; set; } = new List<Opening>();

        [Description("Defines the thickness property and material of the Panel. Orientation of non-isotropic properties are controlled by the OrientationAngle.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        [Angle]
        [Description("Defines the angle that the local x and y axes are rotated around the normal (i.e. local z) of the Panel.\n" +
                     "The normal of the Panel is determined by the right hand curl rule dictated by the order of the edge list.\n" +
                     "Local x is found by projecting the global X to the plane of the Panel and is then rotated with the OrientationAngle, " +
                     "except for the case when the Normal is parallel with the global X. " +
                     "For this case the local y is instead found by projecting global Y to the plane of the Panel and is then rotated with the OrientationAngle.\n" +
                     "The remaining local axis is determined by the right hand rule.")]
        public virtual double OrientationAngle { get; set; } = 0;

        /***************************************************/
    }
}
       


