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

        [Description("If true, 0D elements are detailed. E.g. Points are represented by spheres; Node representation includes the support condition (e.g. pyramid with sphere on top for a Pin).")]
        public virtual bool Detailed0DElements { get; set; } = true;

        [Description("Scale the Element0D representation.")]
        public virtual double Element0DScale { get; set; } = 1;

        [Description("If true, 1D elements are detailed: e.g. the Bars are extruded using their Section property. Else, the Bars' centreline is coarsely piped.")]
        public virtual bool Detailed1DElements { get; set; } = false;

        [Description("Scale the Element1D representation, if applicable. E.g. for Lines, this increases the Pipe size.")]
        public virtual double Element1DScale { get; set; } = 1;

        [Description("If true, 2D elements are detailed. E.g. panels are represented as boxes with their thickness.")]
        public virtual bool Detailed2DElements { get; set; } = false;

        [Description("The key of the BHoMObjects' CustomData dictionary where a custom RenderMesh might be found.")]
        public string CustomRendermeshKey { get; set; } = "Rendermesh";

        [Description("The key of the BHoMObjects' CustomData dictionary where colour information might be found.")]
        public string CustomDataColorKey { get; set; } = "Colour";

        /***************************************************/

    }
}

