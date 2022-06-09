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
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.SurfaceProperties
{
    [Description("Property for 2D analytical elements, made up of a slab on top of parallel ribs running in one direction, all sharing the same material.")]
    public class Ribbed : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Length]
        [Description("The thickness of the slab sitting on top of the ribs.")]
        public virtual double Thickness { get; set; }

        [Description("Homogenous structural material throughout the full thickness of the element.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("Specifies if the ribs are running in local x or y direction.")]
        public virtual PanelDirection Direction { get; set; } = PanelDirection.X;

        [Length]
        [Description("Total depth measured from the bottom of the ribs to the top of the slab.")]
        public virtual double TotalDepth { get; set; }

        [Length]
        [Description("Width of each rib.")]
        public virtual double StemWidth { get; set; }

        [Length]
        [Description("Centre-centre distance between the ribs. Measured perpendicular to the rib direction.")]
        public virtual double Spacing { get; set; }

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;


        /***************************************************/
    }
}



