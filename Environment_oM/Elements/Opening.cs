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
using BH.oM.Dimensional;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Analytical.Elements;
using BH.oM.Environment.Fragments;
using BH.oM.Physical.Constructions;
using System.ComponentModel;

namespace BH.oM.Environment.Elements
{
    [Description("An analytical Opening object (e.g. Window, Door, Hole etc.).")]
    public class Opening : BHoMObject, IEnvironmentObject, IOpening<Edge>, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of Environment Edge objects which define the external boundary of the Opening.")]
        public List<Edge> Edges { get; set; } = new List<Edge>();

        [Description("A construction object providing information about the layers and materials that make up the Opening frame.")]
        public IConstruction FrameConstruction { get; set; } = new Construction();

        [Description("The fraction of the total Opening area that is frame.")]
        public double FrameFactorValue { get; set; } = 0;

        [Description("A collection of Environment Edge objects which define the internal boundary of the Opening.")]
        public List<Edge> InnerEdges { get; set; } = new List<Edge>();

        [Description("A construction object providing information about the layers and materials that make up the Opening pane.")]
        public IConstruction OpeningConstruction { get; set; } = new Construction();

        [Description("The type of Opening (e.g. Window, Door, Hole etc.).")]
        public OpeningType Type { get; set; } = OpeningType.Undefined;

        /***************************************************/
    }
}

