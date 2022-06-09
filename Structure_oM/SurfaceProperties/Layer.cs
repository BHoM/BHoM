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
using BH.oM.Structure.MaterialFragments;
using System.ComponentModel;
using System.Collections.Generic;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SurfaceProperties
{    
    [Description("A layer object with a given material, orientation, and thickness.")]
    public class Layer : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The material this layer is made of.")]
        public virtual IMaterialFragment Material { get; set; }

        [Angle]
        [Description("The orientation of the material in this layer. Orthotropic materials will be oriented with Z parallel to the panel normal direction, and X rotated counterclockwise about the panel normal by this angle from the panel X axis. Not relevant for isotropic materials.")]
        public virtual double Orientation { get; set; } = 0;

        [Length]
        [Description("The thickness of this material layer.")]
        public virtual double Thickness { get; set; } = 0;

        /***************************************************/
    }
}



