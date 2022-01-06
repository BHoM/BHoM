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
    [Description("Defines options for the Meshing of BHoM Objects.")]
    public class RenderMeshOptions : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("Regulate how the Representation of the objects is computed.")]
        public virtual RepresentationOptions RepresentationOptions { get; set; } = new RepresentationOptions();

        [Description("Regulates the refinement of Pipe meshes for 1DElements, i.e. the number of faces of the Pipes.")]
        public virtual double Element1DRefinement { get; set; } = 1;

        [Description("Regulates the refinement of surface meshes for 2DElements.")]
        public virtual double Element2DRefinement { get; set; } = 1;

        [Description("The key of the BHoMObjects' CustomData dictionary where colour information might be found.")]
        public virtual string CustomDataColorKey { get; set; } = "Colour";

        /***************************************************/

    }
}



