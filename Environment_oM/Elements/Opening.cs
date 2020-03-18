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
    [Description("An environment object used to define openings on a panel (e.g. Window, Door)")]
    public class Opening : BHoMObject, IEnvironmentObject, IOpening<Edge>, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of environment Edge objects which define the external boundary of the opening")]
        public List<Edge> Edges { get; set; } = new List<Edge>();

        [Description("A construction object providing construction information about the frame of the opening")]
        public IConstruction FrameConstruction { get; set; } = new Construction();

        [Description("The procentage of the opening that is frame")]
        public double FrameFactorValue { get; set; } = 0;

        [Description("A collection of environment Edge objects which define the internal boundary of the opening")]
        public List<Edge> InnerEdges { get; set; } = new List<Edge>();

        [Description("A construction object providing construction information about the opening - typically gazing construction")]
        public IConstruction OpeningConstruction { get; set; } = new Construction();

        [Description("The type of opening on a panel (e.g. Window, Door). Use OpeningType enum")]
        public OpeningType Type { get; set; } = OpeningType.Undefined;

        /***************************************************/
    }
}

