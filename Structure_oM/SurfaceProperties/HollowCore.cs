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
    [Description("Property for 2D analytical elements, made up of a fixed thickness slab of homogenous material, with a series of parallel holes through it in a particular direction.")]
    public class HollowCore : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A unique Name is required for some structural packages to create and identify the object.")]
        public override string Name { get; set; }

        [Length]
        [Description("Defines the distance the element should be extruded along its normal. By default the element will be extruded half the thickness 'upwards' and half the thickness 'downwards' meaning the element base geoemtry will be in the centre of the extrusion.")]
        public virtual double Thickness { get; set; }

        [Description("Homogenous structural material throughout the full thickness of the element.")]
        public virtual IMaterialFragment Material { get; set; }

        [Description("Defines what type of element this property will be used. Used by some analysis packages.")]
        public virtual PanelType PanelType { get; set; } = PanelType.Slab;

        [Description("Openings of the hollow core.")]
        public virtual IHollowCoreOpeningProfiles Openings { get; set; }

        [Description("Specifies if the hollow cores are running in local x or y direction.")]
        public virtual PanelDirection Direction { get; set; } = PanelDirection.X;

        /***************************************************/
    }
}




