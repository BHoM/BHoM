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
using BH.oM.MEP.Enums;
using BH.oM.MEP.Fragments;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.MEP.System.ConnectionProperties
{
    [Description("A fitting object used to describe interfaces between or along linear MEP elements.")]
    public class Fitting : BHoMObject, IElement0D, ICoincident
    {
        /***************************************************/
        /****                 Properties                ****/
        /***************************************************/

        [Description("The point at which the Fitting occurs.")]
        public virtual Node Location { get; set; } = null;

        [Description("The type of fitting connected to an element..")]
        public virtual FittingType Type { get; set; } = FittingType.Undefined;

        [Description("A DimensionalFragment containing spatial properties of the element.")]
        public virtual DimensionalFragment ElementSize { get; set; } = new DimensionalFragment();

        [Description("A data fragment that contains information regarding the consumption properties of the object.")]
        public virtual List<FlowFragment> Flow { get; set; }

        /***************************************************/
    }
}

