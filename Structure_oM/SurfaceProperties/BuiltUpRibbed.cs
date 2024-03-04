/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SurfaceProperties
{
    [Description("Property for 2D analytical elements, made up of one slab supported by parallel ribs running in one direction beneath them. Ribs and slab can all be made up of different materials.")]
    public class BuiltUpRibbed : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Length]
        [Description("The thickness of the slab sitting on top of the ribs.")]
        public virtual double TopThickness { get; set; }

        [Length]
        [Description("Width of each rib.")]
        public virtual double RibThickness { get; set; }

        [Length]
        [Description("Height of the ribs, equal to the distance between the bottom of the top slab and bottom of the ribs.")]
        public virtual double RibHeight { get; set; }

        [Length]
        [Description("Centre-centre distance between the ribs. Measured perpendicular to the rib direction.")]
        public virtual double RibSpacing { get; set; }

        [Description("Structural material of the top slab. If no material is provided for the ribs then this material is used for them as well.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("Structural material of the ribs. If nothing is provided, the Material will be used instead.")]
        public virtual IMaterialFragment RibMaterial { get; set; }

        [Description("Specifies if the ribs are running in local x or y direction.")]
        public virtual PanelDirection Direction { get; set; } = PanelDirection.X;

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;


        /***************************************************/
    }
}





