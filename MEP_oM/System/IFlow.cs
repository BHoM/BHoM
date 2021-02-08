/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.oM.Dimensional;
using BH.oM.MEP.System.SectionProperties;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.MEP.Fragments;

namespace BH.oM.MEP.System
{
    [Description("Base interface for all flow-based objects. These objects are capable of containing a material or element that flows through the object.")]
    public interface IFlow : IBHoMObject, IElement1D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The point at which the Flow Object begins.")]
        Node StartPoint { get; set; }

        [Description("The point at which the Flow Object ends.")]
        Node EndPoint { get; set; }

        [Description("The section property defines the shape and its associated properties.")]
        List<SectionProfile> SectionProfile { get; set; }

        [Description("A DimensionalFragment containing spatial properties of the element.")]
        DimensionalFragment ElementSize { get; set; }

        /***************************************************/
    }
}

