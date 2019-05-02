/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

using BH.oM.Environment.Fragments;
using BH.oM.Analytical.Elements;
using BH.oM.Physical.Constructions;

namespace BH.oM.Environment.Elements
{
    public class Panel : BHoMObject, IEnvironmentObject, IPanel<Edge, Opening>, IElement2D
    {
        public List<Edge> ExternalEdges { get; set; } = new List<Edge>();
        public List<Opening> Openings { get; set; } = new List<Opening>();
        public IConstruction Construction { get; set; } = new Construction();
        public PanelType Type { get; set; } = PanelType.Undefined;
        public List<string> ConnectedSpaces { get; set; } = new List<string>();

        public List<IBHoMFragment> FragmentProperties { get; set; } = new List<IBHoMFragment>();
    }
}
