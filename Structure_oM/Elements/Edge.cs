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

using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Structure.Constraints;
using BH.oM.Analytical.Elements;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    [Description("Edge class to describe the edges of panels (or other objects) by a curve and properties.")]
    public class Edge : BHoMObject, IElement1D, IEdge
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        
        [Description("Curve of the edge. Should be a planar curve if used on panels.")]            
        public virtual ICurve Curve { get; set; }

        [Description("Release of the edge, defining the connectivity between the host panel and the edge. \n" +
                     "\nThree translational and one rotational degree of freedom, where the rotational refers to the rotation about the axis of the edge.")]
        public virtual Constraint4DOF Release { get; set; } = null;

        [Description("Support of the edge, used to constrain the edge in space.")]
        public virtual Constraint6DOF Support { get; set; } = null;

        
        /***************************************************/
    }
}
       


