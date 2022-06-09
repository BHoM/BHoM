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
    [Description("Property for 2D analytical elements representing a series of layers, each with different thickness, material, and orientation.")]
    public class Layered : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Description("The primary material of the Surface Property. This may represent an 'effective' material model accounting for the composite behavior of the layers, or could be a single material for filtering and take-off.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("The material layers which compose the surface property listed from top surface to bottom.")]
        public virtual List<Layer> Layers { get; set; } = new List<Layer>();

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;

        /***************************************************/
    }
}



