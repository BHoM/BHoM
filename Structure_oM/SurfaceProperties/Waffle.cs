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
using BH.oM.Structure.MaterialFragments;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.Structure.SurfaceProperties
{
    [Description("Property for 2D analytical elements, made up of a slab on top of parallel ribs running in two directions, all sharing the same material.")]
    public class Waffle : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("The thickness of the slab sitting on top of the ribs.")]
        public double Thickness { get; set; }

        [Description("Homogenous structural material throughout the full thickness of the element.")]
        public IMaterialFragment Material { get; set; }

        [Length]
        [Description("Total depth measured from the bottom of the ribs in local x-direction to the top of the slab.")]
        public double TotalDepthX { get; set; }

        [Length]
        [Description("Total depth meassured from the bottom of the ribs in local y-direction to the top of the slab.")]
        public double TotalDepthY { get; set; }

        [Length]
        [Description("Width of each rib in local x-direction.")]
        public double StemWidthX { get; set; }

        [Length]
        [Description("Width of each rib in local y-direction.")]
        public double StemWidthY { get; set; }

        [Length]
        [Description("Centre-Centre distance between the ribs running in local x-direction.")]
        public double SpacingX { get; set; }

        [Length]
        [Description("Centre-Centre distance between the ribs running in local y-direction.")]
        public double SpacingY { get; set; }

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public PanelType PanelType { get; set; } = PanelType.Slab;   //TODO: Required to get Etabs working. To be moved to physical objects


        /***************************************************/
    }
}

