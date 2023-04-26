/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
    [Description("Property for 2D analytical elements, made up of two slabs with parallel ribs running in two directions between them, all sharing the same material.")]
    public class BiDirectionalVoided : BHoMObject, ISurfaceProperty
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
        [Description("The thickness of the slab sitting beneath the ribs.")]
        public virtual double BottomThickness { get; set; }

        [Description("Homogenous structural material throughout the full thickness of the element.")]
        public virtual IMaterialFragment Material { get; set; }

        [Length]
        [Description("Total depth measured from the bottom of the lower slab to the top of the upper slab")]
        public virtual double TotalDepth { get; set; }

        [Length]
        [Description("Width of each rib in local x-direction.")]
        public virtual double StemWidthX { get; set; }

        [Length]
        [Description("Width of each rib in local y-direction.")]
        public virtual double StemWidthY { get; set; }

        [Length]
        [Description("Centre-Centre distance between the ribs running in local x-direction.")]
        public virtual double SpacingX { get; set; }

        [Length]
        [Description("Centre-Centre distance between the ribs running in local y-direction.")]
        public virtual double SpacingY { get; set; }

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;


        /***************************************************/
    }
}



