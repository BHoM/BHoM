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

using System;
using System.Collections.Generic;
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Analytical.Elements;
using BH.oM.Physical.Constructions;
using System.ComponentModel;
using BH.oM.Facade.SectionProperties;

namespace BH.oM.Facade.Elements
{
    [Description("A cutout or hole in a building surface/panel (e.g. Window, Rooflight)")]
    public class Opening : BHoMObject, IFacadeObject, IOpening<FrameEdge>, IElement2D, IElementM
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of FrameEdges which define the external boundary of the opening.")]
        public virtual List<FrameEdge> Edges { get; set; } = new List<FrameEdge>();

        [Description("A construction object providing construction information about the opening - typically glazing construction")]
        public virtual IConstruction OpeningConstruction { get; set; } = null;

        [Description("Frame edge treatment at corners (ie Mitred, Vertical Extends, or Horizontal Extends)")]
        public virtual FrameCornerType FrameCornerType { get; set; } = FrameCornerType.VerticalExtended;

        [Description("The type of opening on a panel (e.g. Window, Door). Use OpeningType enum")]
        public virtual OpeningType Type { get; set; } = OpeningType.Undefined;

        /***************************************************/
    }
}



