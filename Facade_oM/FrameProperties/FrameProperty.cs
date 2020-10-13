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

using System;
using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Analytical.Elements;
using System.ComponentModel;
using BH.oM.Dimensional;

namespace BH.oM.Facade.SectionProperties
{
    [Description("A facade frame object containing construction information about the frame of the opening")]
    public class FrameProperty : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Mullion property for frame sill")]
        public virtual FrameEdgeProperty SillProperty { get; set; } = null;

        [Description("Mullion property for frame head")]
        public virtual FrameEdgeProperty HeadProperty { get; set; }  = null;

        [Description("Mullion property for frame jamb (left)")]
        public virtual FrameEdgeProperty JambLeftProperty { get; set; }  = null;

        [Description("Mullion property for frame jamb (right)")]
        public virtual FrameEdgeProperty JambRightProperty { get; set; }  = null;

        /***************************************************/
    }
}

