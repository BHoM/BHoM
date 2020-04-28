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
    public class RenderMeshOptions : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("If true, 0D elements are detailed. E.g. Points are represented by spheres; Node representation includes the support condition (e.g. pyramid with sphere on top for a Pin).")]
        public bool Detailed0DElements { get; set; } = true;

        [Description("Scale the Element0D representation.")]
        public double Element0DScale { get; set; } = 1;

        [Description("If true, 1D elements are detailed. E.g. the bars are extruded using their Section property.")]
        public bool Detailed1DElements { get; set; } = false;

        [Description("If true, 2D elements are detailed. E.g. panels are represented as boxes with their thickness.")]
        public bool Detailed2DElements { get; set; } = false;

        [Description("Insert the key of the BHoMObjects' CustomData dictionary that contains the color information.")]
        public string CustomDataColorKey { get; set; } = "Colour";

        /***************************************************/

    }
}

