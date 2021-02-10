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
using BH.oM.MEP.Fragments;
using BH.oM.MEP.System.SectionProperties;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.MEP.System.ConnectionProperties;

namespace BH.oM.MEP.System
{
    [Description("An object containing a collection of Wires to work within an MEP systems.")]
    public class WireSegment : BHoMObject, IElementM, IElementF, IFlow
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A DimensionalFragment containing spatial properties of the element.")]
        public virtual DimensionalFragment ElementSize { get; set; } = new DimensionalFragment();

        [Description("The point at which the Wire object begins.")]
        public virtual Node StartPoint { get; set; } = null;

        [Description("The point at which the Wire object ends.")]
        public virtual Node EndPoint { get; set; } = null;

        [Description("Section property of the Wire, containing all material as well as profile geometry and dimensions, where applicable.")]
        public virtual List<SectionProfile> SectionProfile { get; set; } = null;

        [Description("A data fragment that contains information regarding the consumption properties of the object.")]
        public virtual List<FlowFragment> Flow { get; set; }

        [Description("The element's connection properties, such as if it's connected and to what.")]
        public virtual ConnectionProperty ConnectionProperty { get; set; } = null;

        /***************************************************/
    }
}

