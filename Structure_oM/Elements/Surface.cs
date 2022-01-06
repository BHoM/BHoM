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
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    [Description("2D element for structural analysis. " +
                 "\nThe Surface is a freeform surface object defined by a geometrical surface. For planar elements, the Panel is recommended, as it is generally better supported in analysis packages.")]
    public class Surface : BHoMObject, IAreaElement, Analytical.Elements.ISurface
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A geometrical surface defining the 'centre plane` of the surface.")]
        public virtual Geometry.ISurface Extents { get; set; } = null;

        [Description("Defines the thickness property and material of the Element.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        [Description("A planar support for the Surface, constraining the movement in the translational degrees of freedom.")]
        public virtual Constraint3DOF PlanarSpring { get; set; } = null;


        /***************************************************/
    }
}



