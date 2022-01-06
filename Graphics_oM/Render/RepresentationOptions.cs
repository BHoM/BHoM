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
using BH.oM.Geometry;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BH.oM.Graphics
{
    [Description("Defines options for the Representation of BHoM Objects.")]
    public class RepresentationOptions : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("If true, 0D elements are detailed.\nIf `true`, Points are represented by Spheres.\nFor discipline-specific objects, `true` may correspond to e.g. a composite geometry computed based on their properties.")]
        public virtual bool Detailed0DElements { get; set; } = true;

        [Description("Scale the Element0D representation.")]
        public virtual double Element0DScale { get; set; } = 1;

        [Description("If true, 1D elements are detailed.\nIf `true`, Lines are represented by Pipes. For discipline-specific objects, `true` may correspond to e.g. an Extrusion using a cross section property; `false` to pipe using a centreline.")]
        public virtual bool Detailed1DElements { get; set; } = true;

        [Description("Scale the Element1D representation, if applicable.\nFor Lines, this increases the Pipe size.\nDiscipline-specific representations might not be affected by this parameter.")]
        public virtual double Element1DScale { get; set; } = 1;

        [Description("Cap 1D elements, if applicable.\nE.g. for a Line, this caps the computed Pipe.\nFor discipline-specific objects, it may e.g. cap the Extrusions of their cross section.")]
        public virtual bool Cap1DElements { get; set; } = false;

        [Description("If true, 2D elements are detailed.\nFor discipline-specific objects, `true` may correspond to e.g. a box-like geometry representing the 2D element with their thickness, based on its cross section; `false` to e.g. their the middle surface.")]//E.g. panels are represented as boxes with their thickness.")]
        public virtual bool Detailed2DElements { get; set; } = false;

        /***************************************************/

    }
}



